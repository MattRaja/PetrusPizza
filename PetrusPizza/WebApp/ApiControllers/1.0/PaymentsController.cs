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
    /// Payments
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class PaymentsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly PaymentMapper _mapper = new PaymentMapper();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentsController(IAppBLL bll)
        {
            _bll = bll;
        }

        /// <summary>
        /// get all the Payments
        /// </summary>
        /// <returns>Array of Payments</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<V1DTO.PaymentDTO>))]
        public async Task<ActionResult<IEnumerable<V1DTO.PaymentDTO>>> GetPayments()
        {
            var payments = _bll.Payments.GetAllAsync().Result;
            return Ok(payments.Select(e => _mapper.Map(e)));
        }

        /// <summary>
        /// Get a single Payment
        /// </summary>
        /// <param name="id">GpPayment Id</param>
        /// <returns>Payment object</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PaymentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PaymentDTO>> GetPayment(Guid id)
        {
            var Payment = await _bll.Payments.FirstOrDefaultAsync(id);

            if (Payment == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Payment with id {id} not found"));
            }

            return Ok(_mapper.Map( Payment));
        }


        /// <summary>
        /// Update the Payment
        /// </summary>
        /// <param name="id">Payment Id</param>
        /// <param name="PaymentDTO">Payment object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<IActionResult> PutPayment(Guid id, ee.itcollege.mrajam.BLL.App.DTO.Payment PaymentDTO)
        {
            if (id != PaymentDTO.Id)
            {
                return BadRequest(new V1DTO.MessageDTO("Id and Payment.id do not match"));
            }

            if (!await _bll.Payments.ExistsAsync(PaymentDTO.Id, User.UserId<Guid>()))
            {
                return NotFound(new V1DTO.MessageDTO($"Current user does not have session with this id {id}"));
            }
        
            PaymentDTO.AppUserId = User.UserId<Guid>();
            var PaymentApiDTO = new V1DTO.PaymentDTO()
            {
                Id = PaymentDTO.Id,
                PaymentAmount = PaymentDTO.PaymentAmount,
                PaymentDate = PaymentDTO.PaymentDate,
                OrderPayment = PaymentDTO.OrderPayment,
                AppUserId = PaymentDTO.AppUserId
            };
            await _bll.Payments.UpdateAsync(_mapper.Map(PaymentApiDTO));
            await _bll.SaveChangesAsync();
            
            return NoContent();
        }

        /// <summary>
        /// Post the new Payment
        /// </summary>
        /// <param name="Payment"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(V1DTO.PaymentDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PaymentDTO>> PostPayment(V1DTO.PaymentDTO Payment)
        {
            
            // var payments = _bll.Payments.GetAllAsync().Result.ToList();
            // var dto = new PublicApi.DTO.v1.PaymentCreateEditDTO()
            // {
            //     PaymentList = payments
            // };
            // Payment.Id = Guid.NewGuid();
            // Payment.AppUserId = User.UserGuidId();
            //   
            // var bllPayment = new ee.itcollege.mrajam.BLL.App.DTO.Payment()
            // {
            //     Id = Payment.Id,
            //     AppUserId = Payment.AppUserId,
            //     Price = Payment.Price.ToString(),
            //     NameOfPizza = Payment.NameOfPizza,
            //     DefaultPayments = null
            // };
            // await _bll.Payments.AddAndUpdateAsync(bllPayment);
            //     
            // foreach (var defaultPayment in Payment.DefaultPaymentsOut)
            // {
            //     var payment = _bll.Payments.GetAllAsync().Result.First(a => a.PaymentName == defaultPayment);
            //     await _bll.DefaultPayments.AddAndUpdateAsync(Payment, payment);
            // }

            return CreatedAtAction(nameof(GetPayment),
                new {id = Payment.Id, version = HttpContext.GetRequestedApiVersion()?.ToString() ?? "0"},
                Payment);
        }


        /// <summary>
        /// Delete the Payment. Also deletes all the GpsLocations for this session.
        /// </summary>
        /// <param name="id">Payment Id to delete.</param>
        /// <returns>Payment just deleted</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(V1DTO.PaymentDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(V1DTO.MessageDTO))]
        public async Task<ActionResult<V1DTO.PaymentDTO>> DeletePayment(Guid id)
        {
            //Payment? Payment = null;

            var userIdTKey = User.IsInRole("admin") ? null : (Guid?) User.UserId<Guid>();

            var Payment =
                await _bll.Payments.FirstOrDefaultAsync(id, userIdTKey);

            
            if (Payment == null)
            {
                return NotFound(new V1DTO.MessageDTO($"Payment with id {id} not found!"));
            }

            await _bll.Payments.RemoveAsync(Payment, userIdTKey);
            await _bll.SaveChangesAsync();

            return Ok(Payment);
        }


    }
}
