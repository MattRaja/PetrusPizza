// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using ee.itcollege.mrajam.BLL.App.DTO;
// using ee.itcollege.mrajam.BLL.App.DTO.Identity;
// using Contracts.BLL.App;
// using Contracts.DAL.App;
// using Contracts.DAL.App.Repositories;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using Microsoft.EntityFrameworkCore;
// using DAL.App.EF;
// using DAL.App.EF.Repositories;
// using Extensions;
// using Microsoft.AspNetCore.Authorization;
// using WebApp.ViewModels;
//
// namespace WebApp.Controllers
// {
//     /// <summary>
//     /// Custom contoller for paymentMethods
//     /// </summary>
//     [Authorize]
//     public class PaymentMethodController : Controller
//     {
//         private readonly AppDbContext _ctx;
//         private readonly IAppBLL _bll;
//
//         /// <summary>
//         /// constructor
//         /// </summary>
//         /// <param name="bll"></param>
//         public PaymentMethodController(AppDbContext ctx, IAppBLL bll)
//         {
//             _ctx = ctx;
//             _bll = bll;
//         }
//
//         // GET: PaymentMethod
//         /// <summary>
//         /// Show paymentMethods for the logged in user
//         /// </summary>
//         /// <returns></returns>
//         [Authorize(Roles = "admin")]
//         public async Task<IActionResult> Index()
//         {
//             var paymentMethods = await _bll.PaymentMethods.GetAllAsync();
//             return View(paymentMethods);
//         }
//
//         // GET: PaymentMethod/Details/5
//         /// <summary>
//         /// get paymentMethod details
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public async Task<IActionResult> Details(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var paymentMethod = await _ctx.PaymentMethods
//                 .Include(p => p.Payment)
//                 .Include(p => p.Person)
//                 .FirstOrDefaultAsync(p => p.Id == id);
//             if (paymentMethod == null)
//             {
//                 return NotFound();
//             }
//
//             return View(paymentMethod);
//         }
//
//         // GET: PaymentMethod/Create
//         /// <summary>
//         /// 
//         /// </summary>
//         /// <returns></returns>
//         [Authorize(Roles = "admin")]
//         public IActionResult Create()
//         {
//             return View();
//         }
//
//         
//
//
//         // POST: PaymentMethod/Create
//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//         /// <summary>
//         /// create paymentMethod object
//         /// </summary>
//         /// <param name="paymentMethod"></param>
//         /// <returns>form</returns>
//         [Authorize(Roles = "admin")]
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Create([Bind("PersonId,PaymentId,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] ee.itcollege.mrajam.BLL.App.DTO.PaymentMethod paymentMethod)
//         {
//             paymentMethod.AppUserId = User.UserGuidId();
//             if (ModelState.IsValid)
//             {
//                 //paymentMethod.Id = Guid.NewGuid();
//                 _bll.PaymentMethods.Add(paymentMethod);
//                 await _bll.SaveChangesAsync();
//                 return RedirectToAction(nameof(Index));
//             }
//             
//             return View(paymentMethod);
//         }
//
//         // GET: PaymentMethod/Edit/5
//         /// <summary>
//         /// edit paymentMethod object
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public async Task<IActionResult> Edit(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var paymentMethod = await _bll.PaymentMethods.FirstOrDefaultAsync(id.Value, User.UserGuidId());
//             if (paymentMethod == null)
//             {
//                 return NotFound();
//             }
//            
//             return View(paymentMethod);
//         }
//
//         // POST: PaymentMethod/Edit/5
//         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//         // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//         /// <summary>
//         /// edit paymentMethod object
//         /// </summary>
//         /// <param name="id"></param>
//         /// <param name="paymentMethod"></param>
//         /// <returns></returns>
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> Edit(Guid id, [Bind("PersonId,PaymentId,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PaymentMethod paymentMethod)
//         {
//             paymentMethod.AppUserId = User.UserGuidId();
//             if (id != paymentMethod.Id)
//             {
//                 return NotFound();
//             }
//
//             if (ModelState.IsValid)
//             {
//               
//                 await _bll.PaymentMethods.UpdateAsync(paymentMethod);
//                 await _bll.SaveChangesAsync();
//                     
//                 return RedirectToAction(nameof(Index));
//             }
//             
//             return View(paymentMethod);
//         }
//
//         // GET: PaymentMethod/Delete/5
//         /// <summary>
//         /// delete paymentMethod object
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         public async Task<IActionResult> Delete(Guid? id)
//         {
//             if (id == null)
//             {
//                 return NotFound();
//             }
//
//             var paymentMethod = await _ctx.PaymentMethods
//                 .Include(p => p.AppUser)
//                 .Include(p => p.Person)
//                 .FirstOrDefaultAsync(m => m.Id == id);
//
//             if (paymentMethod == null)
//             {
//                 return NotFound();
//             }
//
//             return View(paymentMethod);
//         }
//
//         // POST: PaymentMethod/Delete/5
//         /// <summary>
//         /// delete paymentMethod object
//         /// </summary>
//         /// <param name="id"></param>
//         /// <returns></returns>
//         [HttpPost, ActionName("Delete")]
//         [ValidateAntiForgeryToken]
//         public async Task<IActionResult> DeleteConfirmed(Guid id)
//         {
//             var paymentMethod = await _ctx.PaymentMethods.FindAsync(id);
//             _ctx.PaymentMethods.Remove(paymentMethod);
//             await _ctx.SaveChangesAsync();
//             return RedirectToAction(nameof(Index));
//         }
//
//     }
// }
