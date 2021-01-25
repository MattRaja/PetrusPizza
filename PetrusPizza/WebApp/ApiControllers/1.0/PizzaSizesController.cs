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
    /// PizzaSizes
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PizzaSizesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PizzaSizeMapper _mapper = new PizzaSizeMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PizzaSizesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the PizzaSizes
        /// </summary>
        /// <returns>Array of PizzaSizes</returns>
        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.PizzaSizeDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.PizzaSizeDTO>>> GetPizzaSizes()
        {
            var pizzaSizes = _bll.PizzaSizes.GetAllAsync().Result;
            return Ok(pizzaSizes.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single PizzaSize
        /// </summary>
        /// <param name="id">PizzaSize Id</param>
        /// <returns>PizzaSize object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaSizeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaSizeDTO>> GetPizzaSize(Guid id)
        {
            var PizzaSize = await _bll.PizzaSizes.FirstOrDefaultAsync(id);

            if (PizzaSize == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaSize with id {id} not found"));
            }

            return Ok(_mapper.Map( PizzaSize));
        }


        /// <summary>
        /// Update the PizzaSize
        /// </summary>
        /// <param name="id">PizzaSize Id</param>
        /// <param name="PizzaSizeDTO">PizzaSize object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutPizzaSize(Guid id, ee.itcollege.mrajam.BLL.App.DTO.PizzaSize PizzaSizeDTO)
        {
            if (id != PizzaSizeDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and PizzaSize.id do not match"));
            }

            if (!await _bll.PizzaSizes.ExistsAsync(PizzaSizeDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            PizzaSizeDTO.AppUserId = User.UserId<Guid>();
            var PizzaSizeApiDTO = new V1DTO.PizzaSizeDTO()
            {
                Id = PizzaSizeDTO.Id,
                PizzaSizeName = PizzaSizeDTO.PizzaSizeName,
                Price = PizzaSizeDTO.Price,
                AppUserId = PizzaSizeDTO.AppUserId
            };
            await _bll.PizzaSizes.UpdateAsync(_mapper.Map(PizzaSizeApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new PizzaSize
        /// </summary>
        /// <param name="PizzaSize"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.PizzaSizeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaSizeDTO>> PostPizzaSize(V1DTO.PizzaSizeDTO PizzaSize)
        {
            // Console.WriteLine("inapi");
            // var pizzaSizes = _bll.PizzaSizes.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.PizzaSizeCreateEditDTO()
            // {
            //     PizzaSizeList = pizzaSizes
            // };
            // PizzaSize.Id = Guid.NewGuid();
            // PizzaSize.AppUserId = User.UserGuidId();
            //   
            // var bllPizzaSize = new ee.itcollege.mrajam.BLL.App.DTO.PizzaSize()
            // {
            //     Id = PizzaSize.Id,
            //     AppUserId = PizzaSize.AppUserId,
            //     Price = PizzaSize.Price.ToString(),
            //     NameOfPizza = PizzaSize.NameOfPizza,
            //     DefaultPizzaSizes = null
            // };
            // await _bll.PizzaSizes.AddAndUpdateAsync(bllPizzaSize);
            //     
            // foreach (var defaultPizzaSize in PizzaSize.DefaultPizzaSizesOut)
            // {
            //     var pizzaSize = _bll.PizzaSizes.GetAllAsync().Result.First(a => a.PizzaSizeName == defaultPizzaSize);
            //     await _bll.DefaultPizzaSizes.AddAndUpdateAsync(PizzaSize, pizzaSize);
            // }

            return CreatedAtAction(nameof(GetPizzaSize),
                new {id = PizzaSize.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                PizzaSize);
        }


        /// <summary>
        /// Delete the PizzaSize. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">PizzaSize Id to delete.</param>
        /// <returns>PizzaSize just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaSizeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaSizeDTO>> DeletePizzaSize(Guid id)
        {
            //PizzaSize? PizzaSize = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var PizzaSize =
                await _bll.PizzaSizes.FirstOrDefaultAsync(id, userIdTKey);

            
            if (PizzaSize == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaSize with id {id} not found!"));
            }

            await _bll.PizzaSizes.RemoveAsync(PizzaSize, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(PizzaSize);
        }


    }
}
