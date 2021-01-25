using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublicApi.DTO.v1.Mappers;
using V1DTO=PublicApi.DTO.v1;

namespace WebApp.ApiControllers._1._0
{
    /// <summary>
    /// PizzaOrders
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PizzaOrdersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PizzaOrderMapper _mapper = new PizzaOrderMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PizzaOrdersController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the PizzaOrders
        /// </summary>
        /// <returns>Array of PizzaOrders</returns>
        [HttpGet]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.PizzaOrderDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.PizzaOrderDTO>>> GetPizzaOrders()
        {
            var pizzaOrders = _bll.PizzaOrders.GetAllAsync().Result;
            return Ok(pizzaOrders.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single PizzaOrder
        /// </summary>
        /// <param name="id">GpPizzaOrder Id</param>
        /// <returns>PizzaOrder object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaOrderDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaOrderDTO>> GetPizzaOrder(Guid id)
        {
            var PizzaOrder = await _bll.PizzaOrders.FirstOrDefaultAsync(id);

            if (PizzaOrder == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaOrder with id {id} not found"));
            }

            return Ok(_mapper.Map( PizzaOrder));
        }


        /// <summary>
        /// Update the PizzaOrder
        /// </summary>
        /// <param name="id">PizzaOrder Id</param>
        /// <param name="PizzaOrderDTO">PizzaOrder object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutPizzaOrder(Guid id, ee.itcollege.mrajam.BLL.App.DTO.PizzaOrder PizzaOrderDTO)
        {
            if (id != PizzaOrderDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and PizzaOrder.id do not match"));
            }

            if (!await _bll.PizzaOrders.ExistsAsync(PizzaOrderDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            PizzaOrderDTO.AppUserId = User.UserId<Guid>();
            var PizzaOrderApiDTO = new V1DTO.PizzaOrderDTO()
            {
                Id = PizzaOrderDTO.Id,
                PizzaName = PizzaOrderDTO.PizzaName,
                Price = PizzaOrderDTO.Price,
                AppUserId = PizzaOrderDTO.AppUserId
            };
            await _bll.PizzaOrders.UpdateAsync(_mapper.Map(PizzaOrderApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new PizzaOrder
        /// </summary>
        /// <param name="PizzaOrder"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.PizzaOrderDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaOrderDTO>> PostPizzaOrder(V1DTO.PizzaOrderDTO PizzaOrder)
        {
            // Console.WriteLine("inapi");
            // var pizzaOrders = _bll.PizzaOrders.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.PizzaOrderCreateEditDTO()
            // {
            //     PizzaOrderList = pizzaOrders
            // };
            // PizzaOrder.Id = Guid.NewGuid();
            // PizzaOrder.AppUserId = User.UserGuidId();
            //   
            // var bllPizzaOrder = new ee.itcollege.mrajam.BLL.App.DTO.PizzaOrder()
            // {
            //     Id = PizzaOrder.Id,
            //     AppUserId = PizzaOrder.AppUserId,
            //     Price = PizzaOrder.Price.ToString(),
            //     NameOfPizza = PizzaOrder.NameOfPizza,
            //     DefaultPizzaOrders = null
            // };
            // await _bll.PizzaOrders.AddAndUpdateAsync(bllPizzaOrder);
            //     
            // foreach (var defaultPizzaOrder in PizzaOrder.DefaultPizzaOrdersOut)
            // {
            //     var pizzaOrder = _bll.PizzaOrders.GetAllAsync().Result.First(a => a.PizzaOrderName == defaultPizzaOrder);
            //     await _bll.DefaultPizzaOrders.AddAndUpdateAsync(PizzaOrder, pizzaOrder);
            // }

            return CreatedAtAction(nameof(GetPizzaOrder),
                new {id = PizzaOrder.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                PizzaOrder);
        }


        /// <summary>
        /// Delete the PizzaOrder. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">PizzaOrder Id to delete.</param>
        /// <returns>PizzaOrder just deleted</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaOrderDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaOrderDTO>> DeletePizzaOrder(Guid id)
        {
            //PizzaOrder? PizzaOrder = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var PizzaOrder =
                await _bll.PizzaOrders.FirstOrDefaultAsync(id, userIdTKey);

            
            if (PizzaOrder == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaOrder with id {id} not found!"));
            }

            await _bll.PizzaOrders.RemoveAsync(PizzaOrder, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(PizzaOrder);
        }


    }
}
