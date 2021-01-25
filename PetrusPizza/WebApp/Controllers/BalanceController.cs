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
    /// Custom contoller for balances
    /// </summary>
    [Authorize]
    public class BalanceController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public BalanceController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: Balance
        /// <summary>
        /// Show balances for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var balances = await _bll.Balances.GetAllAsync();
            return View(balances);
        }

        // GET: Balance/Details/5
        /// <summary>
        /// get balance details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _bll.Balances
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // GET: Balance/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: Balance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create balance object
        /// </summary>
        /// <param name="balance"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Payment,Person,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Balance balance)
        {
            
            if (ModelState.IsValid)
            {
                balance.Id = Guid.NewGuid();
                balance.AppUserId = User.UserGuidId();
                _bll.Balances.Add(balance);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", balance.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", balance.GpsSessionTypeId);
            return View();

        }

        // GET: Balance/Edit/5
        /// <summary>
        /// edit balance object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _bll.Balances.FirstOrDefaultAsync((Guid) id);
            if (balance == null)
            {
                return NotFound();
            }
           
            return View(balance);
        }

        // POST: Balance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit balance object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Payment,Person,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Balance balance)
        {
            balance.AppUserId = User.UserGuidId();
            if (id != balance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.Balances.UpdateAsync(balance);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BalanceExists(balance.Id))
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
            
            return View(balance);
        }

        // GET: Balance/Delete/5
        /// <summary>
        /// delete balance object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var balance = await _bll.Balances
                .FirstOrDefaultAsync((Guid) id);

            if (balance == null)
            {
                return NotFound();
            }

            return View(balance);
        }

        // POST: Balance/Delete/5
        /// <summary>
        /// delete balance object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var balance = await _bll.Balances.FirstOrDefaultAsync(id);
            await _bll.Balances.RemoveAsync(balance);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BalanceExists(Guid id)
        {
            return _bll.Balances.ExistsAsync(id).Result;
        }

    }
}
