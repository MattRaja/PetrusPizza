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
    /// ItemRows
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ItemRowsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ItemRowMapper _mapper = new ItemRowMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ItemRowsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the ItemRows
        /// </summary>
        /// <returns>Array of ItemRows</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.ItemRowDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.ItemRowDTO>>> GetItemRows()
        {
            var itemRows = _bll.ItemRows.GetAllAsync().Result;
            return Ok(itemRows.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single ItemRow
        /// </summary>
        /// <param name="id">GpItemRow Id</param>
        /// <returns>ItemRow object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.ItemRowDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ItemRowDTO>> GetItemRow(Guid id)
        {
            var ItemRow = await _bll.ItemRows.FirstOrDefaultAsync(id);

            if (ItemRow == null)
            {
                return NotFound(new V1DTO.MessageDTO($"ItemRow with id {id} not found"));
            }

            return Ok(_mapper.Map( ItemRow));
        }


        /// <summary>
        /// Update the ItemRow
        /// </summary>
        /// <param name="id">ItemRow Id</param>
        /// <param name="ItemRowDTO">ItemRow object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutItemRow(Guid id, ee.itcollege.mrajam.BLL.App.DTO.ItemRow ItemRowDTO)
        {
            if (id != ItemRowDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and ItemRow.id do not match"));
            }

            if (!await _bll.ItemRows.ExistsAsync(ItemRowDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            ItemRowDTO.AppUserId = User.UserId<Guid>();
            var ItemRowApiDTO = new V1DTO.ItemRowDTO()
            {
                Id = ItemRowDTO.Id,
                OrderRows = ItemRowDTO.OrderRows,
                Amount = ItemRowDTO.Amount,
                AppUserId = ItemRowDTO.AppUserId
            };
            await _bll.ItemRows.UpdateAsync(_mapper.Map(ItemRowApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new ItemRow
        /// </summary>
        /// <param name="ItemRow"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.ItemRowDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ItemRowDTO>> PostItemRow(V1DTO.ItemRowDTO ItemRow)
        {
            // Console.WriteLine("inapi");
            // var itemRows = _bll.ItemRows.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.ItemRowCreateEditDTO()
            // {
            //     ItemRowList = itemRows
            // };
            // ItemRow.Id = Guid.NewGuid();
            // ItemRow.AppUserId = User.UserGuidId();
            //   
            // var bllItemRow = new ee.itcollege.mrajam.BLL.App.DTO.ItemRow()
            // {
            //     Id = ItemRow.Id,
            //     AppUserId = ItemRow.AppUserId,
            //     Price = ItemRow.Price.ToString(),
            //     NameOfPizza = ItemRow.NameOfPizza,
            //     DefaultItemRows = null
            // };
            // await _bll.ItemRows.AddAndUpdateAsync(bllItemRow);
            //     
            // foreach (var defaultItemRow in ItemRow.DefaultItemRowsOut)
            // {
            //     var itemRow = _bll.ItemRows.GetAllAsync().Result.First(a => a.ItemRowName == defaultItemRow);
            //     await _bll.DefaultItemRows.AddAndUpdateAsync(ItemRow, itemRow);
            // }

            return CreatedAtAction(nameof(GetItemRow),
                new {id = ItemRow.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                ItemRow);
        }


        /// <summary>
        /// Delete the ItemRow. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">ItemRow Id to delete.</param>
        /// <returns>GpItemRow just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.ItemRowDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ItemRowDTO>> DeleteItemRow(Guid id)
        {
            //ItemRow? ItemRow = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var ItemRow =
                await _bll.ItemRows.FirstOrDefaultAsync(id, userIdTKey);

            
            if (ItemRow == null)
            {
                return NotFound(new V1DTO.MessageDTO($"ItemRow with id {id} not found!"));
            }

            await _bll.ItemRows.RemoveAsync(ItemRow, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(ItemRow);
        }


    }
}
