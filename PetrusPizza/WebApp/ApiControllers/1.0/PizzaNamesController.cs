using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts.BLL.App;
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
    /// PizzaNames
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PizzaNamesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PizzaNameMapper _mapper = new PizzaNameMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PizzaNamesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the PizzaNames
        /// </summary>
        /// <returns>Array of PizzaNames</returns>
        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.PizzaNameDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.PizzaNameDTO>>> GetPizzaNames()
        {
            var defaultToppingsQuery = _bll.DefaultToppings.GetAllAsync().Result;
            var toppings = _bll.Toppings.GetAllAsync().Result;
            var pizzaNames = await _bll.PizzaNames.GetAllAsyncWithDefaultToppings(defaultToppingsQuery, toppings);
            return Ok(pizzaNames.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single PizzaName
        /// </summary>
        /// <param name="id">PizzaName Id</param>
        /// <returns>PizzaName object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaNameDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaNameDTO>> GetPizzaName(Guid id)
        {
            var pizzaName = await _bll.PizzaNames.FirstOrDefaultAsync(id);

            if (pizzaName == null)
            {
                return NotFound(new V1DTO.MessageDTO($"pizzaName with id {id} not found"));
            }

            return Ok(_mapper.Map( pizzaName));
        }


        /// <summary>
        /// Update the PizzaName
        /// </summary>
        /// <param name="id">PizzaName Id</param>
        /// <param name="pizzaNameJsonDTO">pizzaName object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutPizzaName(Guid? id, JsonElement pizzaNameJsonDTO)
        {
            
            var json = pizzaNameJsonDTO.ToString().Split("pizzaName")[0];
          
            var root = JsonConvert.DeserializeObject<V1DTO.PizzaNameJsonDTO>(json);

            var bllPizzaName = new ee.itcollege.mrajam.BLL.App.DTO.PizzaName()
                {
                    Id = (Guid) id!,
                    AppUserId = Guid.Parse(root.AppUserId),
                    Price = root.Price.ToString().Trim(),
                    NameOfPizza = root.NameOfPizza.Trim(),
                    DefaultToppings = null!,
                };
                await _bll.PizzaNames.UpdateAsync(bllPizzaName);

                var defaultToppingsIn = new List<string>();
                var defaultToppingsQuery = _bll.DefaultToppings.GetAllAsync().Result
                    .Where(a => a!.PizzaNameId == bllPizzaName.Id.ToString());
                var toppingsQuery = _bll.Toppings.GetAllAsync().Result;
                foreach (var defaultTopping in defaultToppingsQuery)
                {
                    var topping = toppingsQuery.First(a => a.Id.ToString() == defaultTopping.ToppingId);
                    defaultToppingsIn.Add(topping.ToppingName);
                }
                var defaultToppingsToRemove = defaultToppingsIn.Except(root.DefaultToppingsOut);
                var defaultToppingsToAdd = root.DefaultToppingsOut.Except(defaultToppingsIn);
                var defaultToppings = _bll.DefaultToppings.GetAllAsync().Result;
                foreach (var removable in defaultToppingsToRemove)
                {
                
                    var toppingId = toppingsQuery.First(a => a.ToppingName == removable).Id;
                    var removableId = defaultToppings.First(a => a.ToppingId == toppingId.ToString()).Id;
                    await _bll.DefaultToppings.RemoveAsync(removableId);
                }
                foreach (var addable in defaultToppingsToAdd)
                {
                    var toppingId = toppingsQuery.First(a => a.ToppingName == addable).Id;
                    var defaultToppingDTO = new ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping()
                    {
                        Id = Guid.NewGuid(),
                        PizzaNameId = bllPizzaName.Id.ToString(),
                        AppUserId = bllPizzaName.AppUserId,
                        Price = bllPizzaName.Price.ToString().Trim(),
                        ToppingId = toppingId.ToString()
                    };
                    await _bll.DefaultToppings.AddAndUpdateAsync(defaultToppingDTO);
                }
                    
                await _bll.SaveChangesAsync();

                return NoContent();
        }

        /// <summary>
        /// Post the new PizzaName
        /// </summary>
        /// <param name="pizzaNameJson"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.PizzaNameDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaNameCreateEditDTO>> PostPizzaName(JsonElement pizzaNameJson)
        {
            var json = pizzaNameJson.ToString().Split("pizzaName")[0];
            var root = JsonConvert.DeserializeObject<V1DTO.PizzaNameJsonDTO>(json);
          
           
             var pizzaName = new V1DTO.PizzaNameCreateEditDTO();
             pizzaName.NameOfPizza = root.NameOfPizza;
             pizzaName.Price = decimal.Parse(root.Price);
             pizzaName.DefaultToppingsOut = root.DefaultToppingsOut;
           
             pizzaName.Id = Guid.NewGuid();
             pizzaName.AppUserId = Guid.Parse(root.AppUserId);
            
               
             var bllPizzaName = new ee.itcollege.mrajam.BLL.App.DTO.PizzaName()
             {
                 Id = pizzaName.Id,
                 AppUserId = pizzaName.AppUserId,
                 Price = pizzaName.Price.ToString(),
                 NameOfPizza = pizzaName.NameOfPizza,
                 DefaultToppings = null!
             };
             await _bll.PizzaNames.AddAndUpdateAsync(bllPizzaName);
                 
             foreach (var defaultTopping in pizzaName.DefaultToppingsOut)
             {
                 var topping = _bll.Toppings.GetAllAsync().Result.First(a => a.ToppingName == defaultTopping);
                 await _bll.DefaultToppings!.AddAndUpdateAsync(pizzaName, topping);
             }

            return CreatedAtAction(nameof(GetPizzaName),
                new {id = pizzaName.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                pizzaName);
        }


        /// <summary>
        /// Delete the PizzaName. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">PizzaName Id to delete.</param>
        /// <returns>PizzaName just deleted</returns>
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PizzaNameDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PizzaNameDTO>> DeletePizzaName(Guid? id)
        {
          
          
            Guid? userIdTKey = null;

            var pizzaName =
                await _bll.PizzaNames.FirstOrDefaultAsync(id, userIdTKey);

            if (pizzaName == null)
            {
                return NotFound(new V1DTO.MessageDTO($"PizzaName with id {id} not found!"));
            }

            await _bll.PizzaNames.RemoveAsync(pizzaName, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(pizzaName);
        }


    }
}
