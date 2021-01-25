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
    /// PizzaTypes
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PizzaTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PizzaTypeMapper _mapper = new PizzaTypeMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PizzaTypesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the PizzaTypes
        /// </summary>
        /// <returns>Array of PizzaTypes</returns>
        [HttpGet]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.PizzaTypeDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.PizzaTypeDTO>>> GetPizzaTypes()
        {
          
            var pizzaTypes = _bll.PizzaTypes.GetAllAsync().Result;
            return Ok(pizzaTypes.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single PizzaType
        /// </summary>
        /// <param name="id">PizzaType Id</param>
        /// <returns>PizzaType object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaTypeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaTypeDTO>> GetPizzaType(Guid id)
        {
            var PizzaType = await _bll.PizzaTypes.FirstOrDefaultAsync(id);

            if (PizzaType == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaType with id {id} not found"));
            }

            return Ok(_mapper.Map( PizzaType));
        }


        /// <summary>
        /// Update the PizzaType
        /// </summary>
        /// <param name="id">PizzaType Id</param>
        /// <param name="PizzaTypeDTO">PizzaType object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutPizzaType(Guid id, ee.itcollege.mrajam.BLL.App.DTO.PizzaType PizzaTypeDTO)
        {
            if (id != PizzaTypeDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and PizzaType.id do not match"));
            }

            if (!await _bll.PizzaTypes.ExistsAsync(PizzaTypeDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            PizzaTypeDTO.AppUserId = User.UserId<Guid>();
            var PizzaTypeApiDTO = new V1DTO.PizzaTypeDTO()
            {
                Id = PizzaTypeDTO.Id,
                PizzaTypeName = PizzaTypeDTO.PizzaTypeName,
                Price = PizzaTypeDTO.Price,
                AppUserId = PizzaTypeDTO.AppUserId
            };
            await _bll.PizzaTypes.UpdateAsync(_mapper.Map(PizzaTypeApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new PizzaType
        /// </summary>
        /// <param name="PizzaType"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.PizzaTypeDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaTypeDTO>> PostPizzaType(V1DTO.PizzaTypeDTO PizzaType)
        {
            // Console.WriteLine("inapi");
            // var pizzaTypes = _bll.PizzaTypes.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.PizzaTypeCreateEditDTO()
            // {
            //     PizzaTypeList = pizzaTypes
            // };
            // PizzaType.Id = Guid.NewGuid();
            // PizzaType.AppUserId = User.UserGuidId();
            //   
            // var bllPizzaType = new ee.itcollege.mrajam.BLL.App.DTO.PizzaType()
            // {
            //     Id = PizzaType.Id,
            //     AppUserId = PizzaType.AppUserId,
            //     Price = PizzaType.Price.ToString(),
            //     NameOfPizza = PizzaType.NameOfPizza,
            //     DefaultPizzaTypes = null
            // };
            // await _bll.PizzaTypes.AddAndUpdateAsync(bllPizzaType);
            //     
            // foreach (var defaultPizzaType in PizzaType.DefaultPizzaTypesOut)
            // {
            //     var pizzaType = _bll.PizzaTypes.GetAllAsync().Result.First(a => a.PizzaTypeName == defaultPizzaType);
            //     await _bll.DefaultPizzaTypes.AddAndUpdateAsync(PizzaType, pizzaType);
            // }

            return CreatedAtAction(nameof(GetPizzaType),
                new {id = PizzaType.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                PizzaType);
        }


        /// <summary>
        /// Delete the PizzaType. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">PizzaType Id to delete.</param>
        /// <returns>PizzaType just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaTypeDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaTypeDTO>> DeletePizzaType(Guid id)
        {
            //PizzaType? PizzaType = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var PizzaType =
                await _bll.PizzaTypes.FirstOrDefaultAsync(id, userIdTKey);

            
            if (PizzaType == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaType with id {id} not found!"));
            }

            await _bll.PizzaTypes.RemoveAsync(PizzaType, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(PizzaType);
        }


    }
}
