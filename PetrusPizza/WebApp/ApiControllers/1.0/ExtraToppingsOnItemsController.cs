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
    /// ExtraToppingsOnItems
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ExtraToppingsOnItemsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ExtraToppingsOnItemMapper _mapper = new ExtraToppingsOnItemMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ExtraToppingsOnItemsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the ExtraToppingsOnItems
        /// </summary>
        /// <returns>Array of ExtraToppingsOnItems</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.ExtraToppingsOnItemDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.ExtraToppingsOnItemDTO>>> GetExtraToppingsOnItems()
        {
            var extraToppingsOnItems = _bll.ExtraToppingsOnItems.GetAllAsync().Result;
            return Ok(extraToppingsOnItems.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single ExtraToppingsOnItem
        /// </summary>
        /// <param name="id">GpExtraToppingOnItem Id</param>
        /// <returns>ExtraToppingsOnItem object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.ExtraToppingsOnItemDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ExtraToppingsOnItemDTO>> GetExtraToppingsOnItem(Guid id)
        {
            var ExtraToppingsOnItem = await _bll.ExtraToppingsOnItems.FirstOrDefaultAsync(id);

            if (ExtraToppingsOnItem == null)
            {
                return NotFound(new V1DTO.MessageDTO($"ExtraToppingsOnItem with id {id} not found"));
            }

            return Ok(_mapper.Map( ExtraToppingsOnItem));
        }


        /// <summary>
        /// Update the ExtraToppingsOnItem
        /// </summary>
        /// <param name="id">ExtraToppingOnItem Id</param>
        /// <param name="ExtraToppingsOnItemDTO">ExtraToppingsOnItem object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutExtraToppingsOnItem(Guid id, ee.itcollege.mrajam.BLL.App.DTO.ExtraToppingsOnItem ExtraToppingsOnItemDTO)
        {
            if (id != ExtraToppingsOnItemDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and ExtraToppingsOnItem.id do not match"));
            }

            if (!await _bll.ExtraToppingsOnItems.ExistsAsync(ExtraToppingsOnItemDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            ExtraToppingsOnItemDTO.AppUserId = User.UserId<Guid>();
            var ExtraToppingsOnItemApiDTO = new V1DTO.ExtraToppingsOnItemDTO()
            {
                Id = ExtraToppingsOnItemDTO.Id,
                ToppingName = ExtraToppingsOnItemDTO.ToppingName,
                OrderRows = ExtraToppingsOnItemDTO.OrderRows,
                Price = ExtraToppingsOnItemDTO.Price,
                AppUserId = ExtraToppingsOnItemDTO.AppUserId
            };
            await _bll.ExtraToppingsOnItems.UpdateAsync(_mapper.Map(ExtraToppingsOnItemApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new ExtraToppingsOnItem
        /// </summary>
        /// <param name="ExtraToppingsOnItem"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.ExtraToppingsOnItemDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ExtraToppingsOnItemDTO>> PostExtraToppingsOnItem(V1DTO.ExtraToppingsOnItemDTO ExtraToppingsOnItem)
        {
            // Console.WriteLine("inapi");
            // var extraToppingsOnItems = _bll.ExtraToppingsOnItems.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.ExtraToppingsOnItemCreateEditDTO()
            // {
            //     ExtraToppingsOnItemList = extraToppingsOnItems
            // };
            // ExtraToppingsOnItem.Id = Guid.NewGuid();
            // ExtraToppingsOnItem.AppUserId = User.UserGuidId();
            //   
            // var bllExtraToppingsOnItem = new ee.itcollege.mrajam.BLL.App.DTO.ExtraToppingsOnItem()
            // {
            //     Id = ExtraToppingsOnItem.Id,
            //     AppUserId = ExtraToppingsOnItem.AppUserId,
            //     Price = ExtraToppingsOnItem.Price.ToString(),
            //     NameOfPizza = ExtraToppingsOnItem.NameOfPizza,
            //     DefaultExtraToppingsOnItems = null
            // };
            // await _bll.ExtraToppingsOnItems.AddAndUpdateAsync(bllExtraToppingsOnItem);
            //     
            // foreach (var defaultExtraToppingsOnItem in ExtraToppingsOnItem.DefaultExtraToppingsOnItemsOut)
            // {
            //     var extraToppingsOnItem = _bll.ExtraToppingsOnItems.GetAllAsync().Result.First(a => a.ExtraToppingsOnItemName == defaultExtraToppingsOnItem);
            //     await _bll.DefaultExtraToppingsOnItems.AddAndUpdateAsync(ExtraToppingsOnItem, extraToppingsOnItem);
            // }

            return CreatedAtAction(nameof(GetExtraToppingsOnItem),
                new {id = ExtraToppingsOnItem.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                ExtraToppingsOnItem);
        }


        /// <summary>
        /// Delete the ExtraToppingsOnItem. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">ExtraToppingOnItem Id to delete.</param>
        /// <returns>ExtraToppingOnItem just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.ExtraToppingsOnItemDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ExtraToppingsOnItemDTO>> DeleteExtraToppingsOnItem(Guid id)
        {
            //ExtraToppingsOnItem? ExtraToppingsOnItem = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var ExtraToppingsOnItem =
                await _bll.ExtraToppingsOnItems.FirstOrDefaultAsync(id, userIdTKey);

            
            if (ExtraToppingsOnItem == null)
            {
                return NotFound(new V1DTO.MessageDTO($"ExtraToppingsOnItem with id {id} not found!"));
            }

            await _bll.ExtraToppingsOnItems.RemoveAsync(ExtraToppingsOnItem, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(ExtraToppingsOnItem);
        }


    }
}
