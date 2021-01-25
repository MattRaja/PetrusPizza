// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Contracts.BLL.App;
// using Domain.App;
// using Extensions;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using PublicApi.DTO.v1;
//
// namespace WebApp.ApiControllers._1._0
// {
//     /// <summary>
//     /// controller for paymentmethods
//     /// </summary>
//     [ApiController]
//     [ApiVersion( "1.0" )]
//     [Route("api/v{version:apiVersion}/[controller]")]
//     [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
//     public class PaymentMethodsController : ControllerBase
//     {
//         //private readonly IAppUnitOfWork _bll;
//         private readonly IAppBLL _bll;
//
//         /// <summary>
//         /// constructor
//         /// </summary>
//         /// <param name="bll"></param>
//         public PaymentMethodsController(IAppBLL bll)
//         {
//             _bll = bll;
//         }
//
//
//         // GET: api/PaymentMethods
//         /// <summary>
//         /// get PaymentMethodDTO object from data source
//         /// </summary>
//         /// <returns>status</returns>
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<PaymentMethodDTO>>> GetPaymentMethods()
//         {
//             var paymentMethodDTOs = await _bll.PaymentMethods.AllAsync(User.UserGuidId());
//             
//             return Ok(paymentMethodDTOs);
//         }
//
//         /// <summary>
//         ///  Find and return PaymentMethod from datasource
//         /// </summary>
//         /// <param name="id">paymentMethod id - guid</param>
//         /// <returns>PaymentMethod object based on id</returns>
//         /// <response code="200">The paymentMethod was successfully retrieved.</response>
//         /// <response code="404">The paymentMethod does not exist.</response>
//         [ProducesResponseType( typeof( PaymentMethod ), 200 )]	
//         [ProducesResponseType( 404 )]	
//         [HttpGet("{id}")]
//         public async Task<ActionResult<PaymentMethodDTO>> GetPaymentMethod(Guid id)
//         {
//             var paymentMethod = await _bll.PaymentMethods.FirstOrDefaultAsync(id, User.UserGuidId());
//
//             if (paymentMethod == null)
//             {
//                 return NotFound();
//             }
//
//             return Ok(paymentMethod);
//         }
//
//         // PUT: api/PaymentMethods/5
//         /// <summary>
//         /// update PaymentMethod object
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="PaymentMethodEditDTO"></param>
//         /// <returns>status</returns>
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutPaymentMethod(Guid id, PaymentMethodEditDTO PaymentMethodEditDTO)
//         {
//             if (id != PaymentMethodEditDTO.Id)
//             {
//                 return BadRequest();
//             }
//
//             var paymentMethod = await _bll.PaymentMethods.FirstOrDefaultAsync(PaymentMethodEditDTO.Id, User.UserGuidId());
//             if (paymentMethod == null)
//             {
//                 return BadRequest();
//             }
//
//             //paymentMethod.Payments = PaymentMethodEditDTO.Payments ?? new List<Payment>();
//             paymentMethod.PaymentMethodName = PaymentMethodEditDTO!.PaymentMethodName;
//             
//             _bll.PaymentMethods.Update(paymentMethod);
//
//
//             try
//             {
//                 await _bll.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!await _bll.PaymentMethods.ExistsAsync(id, User.UserGuidId()))
//                 {
//                     return NotFound();
//                 }
//
//                 throw;
//             }
//
//             return NoContent();
//         }
//
//         // POST: api/PaymentMethods
//         /// <summary>
//         /// add PaymentMethod object
//         /// </summary>
//         /// <param name="paymentMethodCreateDTO"></param>
//         /// <returns>status</returns>
//         [HttpPost]
//         public async Task<ActionResult<PaymentMethod>> PostPaymentMethod(PaymentMethodCreateDTO paymentMethodCreateDTO)
//         {
//             var paymentMethod = new ee.itcollege.mrajam.BLL.App.DTO.PaymentMethod
//             {
//                 //Payments = paymentMethodCreateDTO.Payments ?? new List<Payment>(),
//                 PaymentMethodName = paymentMethodCreateDTO.PaymentMethodName
//             };
//
//             _bll.PaymentMethods.Add(paymentMethod);
//             await _bll.SaveChangesAsync();
//
//             return CreatedAtAction("GetPaymentMethod", new {id = paymentMethod.Id}, paymentMethod);
//         }
//
//         // DELETE: api/PaymentMethods/5
//         /// <summary>
//         /// delete PaymentMethod object
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns>status</returns>
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod(Guid id)
//         {
//             var paymentMethod = await _bll.PaymentMethods.FirstOrDefaultAsync(id, User.UserGuidId());
//             if (paymentMethod == null)
//             {
//                 return NotFound();
//             }
//
//             _bll.PaymentMethods.Remove(paymentMethod);
//             await _bll.SaveChangesAsync();
//
//             return Ok(paymentMethod);
//         }
//     }
// }
