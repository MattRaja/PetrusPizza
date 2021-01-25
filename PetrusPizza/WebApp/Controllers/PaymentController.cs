using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    /// <summary>
    /// Custom contoller for payments
    /// </summary>
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public PaymentController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: Payment
        /// <summary>
        /// Show payments for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var payments = await _bll.Payments.GetAllAsync();
            return View(payments);
        }

        // GET: Payment/Details/5
        /// <summary>
        /// get payment details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payment/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create payment object
        /// </summary>
        /// <param name="payment"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderPayment,PaymentDate,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Payment payment)
        {
            
            if (ModelState.IsValid)
            {
                payment.Id = Guid.NewGuid();
                payment.AppUserId = User.UserGuidId();
                _bll.Payments.Add(payment);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", payment.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", payment.GpsSessionTypeId);
            return View();

        }

        // GET: Payment/Edit/5
        /// <summary>
        /// edit payment object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments.FirstOrDefaultAsync((Guid) id);
            if (payment == null)
            {
                return NotFound();
            }
           
            return View(payment);
        }

        // POST: Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit payment object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrderPayment,PaymentDate,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Payment payment)
        {
            payment.AppUserId = User.UserGuidId();
            if (id != payment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.Payments.UpdateAsync(payment);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                    
                return RedirectToAction(nameof(Index));
            }
            
            return View(payment);
        }

        // GET: Payment/Delete/5
        /// <summary>
        /// delete payment object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _bll.Payments
                .FirstOrDefaultAsync((Guid) id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payment/Delete/5
        /// <summary>
        /// delete payment object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var payment = await _bll.Payments.FirstOrDefaultAsync(id);
            await _bll.Payments.RemoveAsync(payment);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(Guid id)
        {
            return _bll.Payments.ExistsAsync(id).Result;
        }

    }
}
