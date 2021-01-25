using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PublicApi.DTO.v1.Mappers;
using V1DTO=PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    /// <summary>
    /// OrderRows
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class OrderRowsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly OrderRowMapper _mapper = new OrderRowMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public OrderRowsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the OrderRows
        /// </summary>
        /// <returns>Array of OrderRows</returns>
        [HttpGet]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.OrderRowDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.OrderRowCartDTO>>> GetOrderRows()
        {
            var a = new List<V1DTO.OrderRowDTO>();
            var orderRows = _bll.OrderRows.GetAllAsync().Result.Where(p => p.OrderId == null);
            foreach (var row in orderRows)
            {
                a.Add(new V1DTO.OrderRowDTO()
                {
                    Id = row.Id,
                    AppUserId = row.AppUserId,
                    NameOfPizza = row.NameOfPizza,
                    PizzaSize = row.PizzaSize,
                    PizzaType = row.PizzaType,
                    SumWithVAT = row.SumWithVAT
                });
            }
            return Ok(a.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single OrderRow
        /// </summary>
        /// <param name="id">GpOrderRow Id</param>
        /// <returns>OrderRow object</returns>
        [HttpGet("{id}")]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.OrderRowDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.OrderRowDTO>> GetOrderRow(Guid id)
        {
            var OrderRow = await _bll.OrderRows.FirstOrDefaultAsync(id);

            if (OrderRow == null)
            {
                return NotFound(new V1DTO.MessageDTO($"OrderRow with id {id} not found"));
            }

            return Ok(_mapper.Map( OrderRow));
        }


        /// <summary>
        /// Update the OrderRow
        /// </summary>
        /// <param name="id">OrderRow Id</param>
        /// <param name="OrderRowDTO">OrderRow object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutOrderRow(Guid id, ee.itcollege.mrajam.BLL.App.DTO.OrderRow OrderRowDTO)
        {
            if (id != OrderRowDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and OrderRow.id do not match"));
            }

            if (!await _bll.OrderRows.ExistsAsync(OrderRowDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            OrderRowDTO.AppUserId = User.UserId<Guid>();
            var OrderRowApiDTO = new V1DTO.OrderRowDTO()
            {
                Id = OrderRowDTO.Id,
                Price = OrderRowDTO.Price,
                Sum = OrderRowDTO.Sum,
                SumWithVAT = OrderRowDTO.SumWithVAT,
                AppUserId = OrderRowDTO.AppUserId
            };
            await _bll.OrderRows.UpdateAsync(_mapper.Map(OrderRowApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new OrderRow
        /// </summary>
        /// <param name="OrderRowJson"></param>
        /// <returns></returns>
        //[Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.OrderRowDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.OrderRowDTO>> PostOrderRow(JsonElement OrderRowJson)
        {
            
            var json = OrderRowJson.ToString().Split("orderRow")[0];
        
            var root = JsonConvert.DeserializeObject<V1DTO.OrderRowCreateDTO>(json);

            var pizzaSizecost = _bll.PizzaSizes.GetAllAsync().Result
                .First(p => p.PizzaSizeName == root.PizzaSize).Price;
            var pizzaTypecost = _bll.PizzaTypes.GetAllAsync().Result
                .First(p => p.PizzaTypeName == root.PizzaType).Price;

            var sum = root.Price + decimal.Parse(pizzaSizecost) + decimal.Parse(pizzaTypecost);

            var toppingsQuery = _bll.Toppings.GetAllAsync().Result;
            foreach (var topping in root.ExtraToppingsOnItems)
            {
                
                sum += decimal.Parse(toppingsQuery.First(p => p.ToppingName == topping).Price);
                
            }

            var vat = 20;
            var bllOrderRow = new ee.itcollege.mrajam.BLL.App.DTO.OrderRow()
            {
                Id = Guid.NewGuid(),
                AppUserId = Guid.Parse(root.AppUserId),
                Price = root.Price,
                NameOfPizza = root.NameOfPizza,
                VAT = vat,
                Sum = sum,
                SumWithVAT = sum + sum * (vat/100),
                PizzaSize = root.PizzaSize,
                PizzaType = root.PizzaType
            };
            await _bll.OrderRows.AddAndUpdateAsync(bllOrderRow);

            return CreatedAtAction(nameof(GetOrderRow),
                new {id = bllOrderRow.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                bllOrderRow);
        }


        /// <summary>
        /// Delete the OrderRow. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">OrderRow Id to delete.</param>
        /// <returns>OrderRow just deleted</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.OrderRowDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.OrderRowDTO>> DeleteOrderRow(Guid id)
        {
            //OrderRow? OrderRow = null;

            Guid? userIdTKey = null;

            var OrderRow =
                await _bll.OrderRows.FirstOrDefaultAsync(id, userIdTKey);

            
            if (OrderRow == null)
            {
                return NotFound(new V1DTO.MessageDTO($"OrderRow with id {id} not found!"));
            }

            await _bll.OrderRows.RemoveAsync(OrderRow, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(OrderRow);
        }


    }
}
