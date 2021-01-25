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
    /// Custom contoller for toppings
    /// </summary>
    [Authorize]
    public class ToppingController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public ToppingController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: Topping
        /// <summary>
        /// Show toppings for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var toppings = await _bll.Toppings.GetAllAsync();
            return View(toppings);
        }

        // GET: Topping/Details/5
        /// <summary>
        /// get topping details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topping = await _bll.Toppings
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (topping == null)
            {
                return NotFound();
            }

            return View(topping);
        }

        // GET: Topping/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: Topping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create topping object
        /// </summary>
        /// <param name="topping"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToppingName,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Topping topping)
        {
          
            if (ModelState.IsValid)
            {
                topping.Id = Guid.NewGuid();
                topping.AppUserId = User.UserGuidId();
                topping.Price = topping.Price.Trim();
                topping.ToppingName = topping.ToppingName.Trim();
                await _bll.Toppings.AddAndUpdateAsync(topping);
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", topping.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", topping.GpsSessionTypeId);
            return View();

        }

        // GET: Topping/Edit/5
        /// <summary>
        /// edit topping object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topping = await _bll.Toppings.FirstOrDefaultAsync((Guid) id);
            if (topping == null)
            {
                return NotFound();
            }
           
            return View(topping);
        }

        // POST: Topping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit topping object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topping"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ToppingName,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Topping topping)
        {
            topping.AppUserId = User.UserGuidId();
            if (id != topping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    topping.ToppingName = topping.ToppingName.Trim();
                    topping.Price = topping.Price.Trim();
                    await _bll.Toppings.UpdateAsync(topping);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToppingExists(topping.Id))
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
            
            return View(topping);
        }

        // GET: Topping/Delete/5
        /// <summary>
        /// delete topping object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topping = await _bll.Toppings
                .FirstOrDefaultAsync((Guid) id);

            if (topping == null)
            {
                return NotFound();
            }

            return View(topping);
        }

        // POST: Topping/Delete/5
        /// <summary>
        /// delete topping object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var topping = await _bll.Toppings.FirstOrDefaultAsync(id);
            await _bll.Toppings.RemoveAsync(topping);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToppingExists(Guid id)
        {
            return _bll.Toppings.ExistsAsync(id).Result;
        }

    }
}
