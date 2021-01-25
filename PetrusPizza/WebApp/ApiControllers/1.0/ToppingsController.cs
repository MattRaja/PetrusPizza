using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
    /// Toppings
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class ToppingsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly ToppingMapper _mapper = new ToppingMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ToppingsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the Toppings
        /// </summary>
        /// <returns>Array of Toppings</returns>
        [HttpGet]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.ToppingDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.ToppingDTO>>> GetToppings()
        {
          
            var toppings = _bll.Toppings.GetAllAsync().Result;
        
            return Ok(toppings.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single Topping
        /// </summary>
        /// <param name="id">Topping Id</param>
        /// <returns>Topping object</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.ToppingDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ToppingDTO>> GetTopping(Guid id)
        {
            var Topping = await _bll.Toppings.FirstOrDefaultAsync(id);

            if (Topping == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Topping with id {id} not found"));
            }

            return Ok(_mapper.Map( Topping));
        }


        /// <summary>
        /// Update the Topping
        /// </summary>
        /// <param name="id">Topping Id</param>
        /// <param name="ToppingJson">Topping object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutTopping(Guid id, JsonElement ToppingJson)
        {
            // if (id != ToppingJsonDTO.Id)
            // {
            //     return BadRequest(new V1DTO.MessageDTO("Id and Topping.id do not match"));
            // }
            //
            // if (!await _bll.Toppings.ExistsAsync(ToppingJsonDTO.Id, User.UserId<Guid>()))
            // {
            //     return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            // }
        
            //V1DTO.ToppingJsonDTO.AppUserId = User.UserId<Guid>();
            
            var json = ToppingJson.ToString().Split("topping")[0];
            var root = JsonConvert.DeserializeObject<V1DTO.ToppingJsonDTO>(json);
          

            var toppingId = _bll.Toppings.GetAllAsync().Result
                .First(p => p.ToppingName == root.ToppingName).Id;

            var topping = new V1DTO.ToppingDTO()
            {
                Id = toppingId,
                ToppingName = root.ToppingName,
                Price = root.Price,
                AppUserId = root.AppUserId,
            };
           
            await _bll.Toppings.UpdateAsync(_mapper.Map(topping));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new Topping
        /// </summary>
        /// <param name="toppingJson"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.ToppingDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ToppingDTO>> PostTopping(JsonElement toppingJson)
        {
            var json = toppingJson.ToString().Split("topping")[0];
            var root = JsonConvert.DeserializeObject<V1DTO.ToppingJsonDTO>(json);
         
           
            var topping = new V1DTO.ToppingDTO();
            topping.ToppingName = root.ToppingName;
            topping.Price = root.Price;
          
            topping.Id = Guid.NewGuid();
            topping.AppUserId = root.AppUserId;
               
            var bllTopping = new ee.itcollege.mrajam.BLL.App.DTO.Topping()
            {
                Id = topping.Id,
                AppUserId = topping.AppUserId,
                Price = topping.Price,
                ToppingName = topping.ToppingName,
            };
            await _bll.Toppings.AddAndUpdateAsync(bllTopping);

            return CreatedAtAction(nameof(GetTopping),
                new {id = topping.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                topping);
        }


        /// <summary>
        /// Delete the Topping. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">Topping Id to delete.</param>
        /// <returns>Topping just deleted</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.ToppingDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.ToppingDTO>> DeleteTopping(Guid id)
        {
         
            Guid? userIdTKey = null;

            var topping =
                await _bll.Toppings.FirstOrDefaultAsync(id, userIdTKey);

            if (topping == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Topping with id {id} not found!"));
            }

            await _bll.Toppings.RemoveAsync(topping, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(topping);
        }


    }
}
