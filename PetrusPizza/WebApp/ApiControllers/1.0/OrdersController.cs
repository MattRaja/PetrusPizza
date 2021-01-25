using System;
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
    /// Orders
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class OrdersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly OrderMapper _mapper = new OrderMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public OrdersController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the Orders
        /// </summary>
        /// <returns>Array of Orders</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.OrderDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.OrderDTO>>> GetOrders()
        {
            var orders = _bll.Orders.GetAllAsync().Result;
            return Ok(orders.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single Order
        /// </summary>
        /// <param name="id">GpOrder Id</param>
        /// <returns>Order object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.OrderDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.OrderDTO>> GetOrder(Guid id)
        {
            var Order = await _bll.Orders.FirstOrDefaultAsync(id);

            if (Order == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Order with id {id} not found"));
            }

            return Ok(_mapper.Map( Order));
        }


        /// <summary>
        /// Update the Order
        /// </summary>
        /// <param name="id">Order Id</param>
        /// <param name="OrderDTO">Order object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutOrder(Guid id, ee.itcollege.mrajam.BLL.App.DTO.Order OrderDTO)
        {
            if (id != OrderDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and Order.id do not match"));
            }

            if (!await _bll.Orders.ExistsAsync(OrderDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            OrderDTO.AppUserId = User.UserId<Guid>();
            var OrderApiDTO = new V1DTO.OrderDTO()
            {
                Id = OrderDTO.Id,
                OrderDate = OrderDTO.OrderDate,
                OrderNr = OrderDTO.OrderNr,
                OrderRows = OrderDTO.OrderRows,
                SumWithoutVAT = OrderDTO.SumWithoutVAT,
                SumWithVAT = OrderDTO.SumWithVAT,
            };
            await _bll.Orders.UpdateAsync(_mapper.Map(OrderApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new Order
        /// </summary>
        /// <param name="OrderJson"></param>
        /// <returns></returns>
        //[Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.OrderDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.OrderDTO>> PostOrder(JsonElement OrderJson)
        {
            var json = OrderJson.ToString().Split("Order")[0];
         
            var root = JsonConvert.DeserializeObject<V1DTO.OrderDTO>(json);
            var orderId = Guid.NewGuid();
            var orderCount = _bll.Orders.GetAllAsync().Result.ToList().Count;
            var bllOrder = new ee.itcollege.mrajam.BLL.App.DTO.Order()
            {
                Id = orderId,
                OrderNr = (orderCount + 1).ToString(),
                OrderDate = DateTime.Now,
            };
            await _bll.Orders.AddAndUpdateAsync(bllOrder);
            var orderRows = _bll.OrderRows.GetAllAsync().Result
                .Where(p => p.AppUserId == Guid.Parse(root.AppUserId));
            foreach (var row in orderRows)
            {
                row.OrderId = orderId;
                await _bll.OrderRows.UpdateAsync(row);
            }
            var order = _bll.Orders.GetAllAsync().Result.First(p => p.Id == orderId);
            order.AppUserId = Guid.Parse(root.AppUserId);
            await _bll.Orders.UpdateAsync(order);
            return CreatedAtAction(nameof(GetOrder),
                new {id = orderId, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                bllOrder);
        }


        /// <summary>
        /// Delete the Order. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">Order Id to delete.</param>
        /// <returns>Order just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.OrderDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.OrderDTO>> DeleteOrder(Guid id)
        {
            //Order? Order = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var Order =
                await _bll.Orders.FirstOrDefaultAsync(id, userIdTKey);

            
            if (Order == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Order with id {id} not found!"));
            }

            await _bll.Orders.RemoveAsync(Order, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(Order);
        }


    }
}
