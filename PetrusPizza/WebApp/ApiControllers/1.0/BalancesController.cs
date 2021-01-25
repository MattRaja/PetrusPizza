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
    /// Balances
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class BalancesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly BalanceMapper _mapper = new BalanceMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BalancesController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the Balances
        /// </summary>
        /// <returns>Array of Balances</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.BalanceDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.BalanceDTO>>> GetBalances()
        {
            var balances = _bll.Balances.GetAllAsync().Result;
            return Ok(balances.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single Balance
        /// </summary>
        /// <param name="id">GpBalance Id</param>
        /// <returns>Balance object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.BalanceDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.BalanceDTO>> GetBalance(Guid id)
        {
            var Balance = await _bll.Balances.FirstOrDefaultAsync(id);

            if (Balance == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Balance with id {id} not found"));
            }

            return Ok(_mapper.Map( Balance));
        }


        /// <summary>
        /// Update the Balance
        /// </summary>
        /// <param name="id">Balance Id</param>
        /// <param name="BalanceDTO">Balance object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutBalance(Guid id, ee.itcollege.mrajam.BLL.App.DTO.Balance BalanceDTO)
        {
            if (id != BalanceDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and Balance.id do not match"));
            }

            if (!await _bll.Balances.ExistsAsync(BalanceDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            BalanceDTO.AppUserId = User.UserId<Guid>();
            var BalanceApiDTO = new V1DTO.BalanceDTO()
            {
                Id = BalanceDTO.Id,
                PaymentId = BalanceDTO.PaymentId,
                AppUserId = BalanceDTO.AppUserId
            };
            await _bll.Balances.UpdateAsync(_mapper.Map(BalanceApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new Balance
        /// </summary>
        /// <param name="Balance"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.BalanceDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.BalanceDTO>> PostBalance(V1DTO.BalanceDTO Balance)
        {
          
            // var balances = _bll.Balances.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.BalanceCreateEditDTO()
            // {
            //     BalanceList = balances
            // };
            // Balance.Id = Guid.NewGuid();
            // Balance.AppUserId = User.UserGuidId();
            //   
            // var bllBalance = new ee.itcollege.mrajam.BLL.App.DTO.Balance()
            // {
            //     Id = Balance.Id,
            //     AppUserId = Balance.AppUserId,
            //     Price = Balance.Price.ToString(),
            //     NameOfPizza = Balance.NameOfPizza,
            //     DefaultBalances = null
            // };
            // await _bll.Balances.AddAndUpdateAsync(bllBalance);
            //     
            // foreach (var defaultBalance in Balance.DefaultBalancesOut)
            // {
            //     var balance = _bll.Balances.GetAllAsync().Result.First(a => a.BalanceName == defaultBalance);
            //     await _bll.DefaultBalances.AddAndUpdateAsync(Balance, balance);
            // }

            return CreatedAtAction(nameof(GetBalance),
                new {id = Balance.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                Balance);
        }


        /// <summary>
        /// Delete the Balance. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">Balance Id to delete.</param>
        /// <returns>Balance just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.BalanceDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.BalanceDTO>> DeleteBalance(Guid id)
        {
            //Balance? Balance = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var Balance =
                await _bll.Balances.FirstOrDefaultAsync(id, userIdTKey);

            
            if (Balance == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Balance with id {id} not found!"));
            }

            await _bll.Balances.RemoveAsync(Balance, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(Balance);
        }


    }
}
