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
    /// Custom contoller for defaultToppings
    /// </summary>
    [Authorize]
    public class DefaultToppingController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public DefaultToppingController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: DefaultTopping
        /// <summary>
        /// Show defaultToppings for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var defaultToppings = await _bll.DefaultToppings.GetAllAsync();
            return View(defaultToppings);
        }

        // GET: DefaultTopping/Details/5
        /// <summary>
        /// get defaultTopping details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defaultTopping = await _bll.DefaultToppings
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (defaultTopping == null)
            {
                return NotFound();
            }

            return View(defaultTopping);
        }

        // GET: DefaultTopping/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: DefaultTopping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create defaultTopping object
        /// </summary>
        /// <param name="defaultTopping"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PizzaName,ToppingName,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] DefaultTopping defaultTopping)
        {
            
            if (ModelState.IsValid)
            {
                defaultTopping.Id = Guid.NewGuid();
                defaultTopping.AppUserId = User.UserGuidId();
                _bll.DefaultToppings.Add(defaultTopping);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", defaultTopping.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", defaultTopping.GpsSessionTypeId);
            return View();

        }

        // GET: DefaultTopping/Edit/5
        /// <summary>
        /// edit defaultTopping object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defaultTopping = await _bll.DefaultToppings.FirstOrDefaultAsync((Guid) id);
            if (defaultTopping == null)
            {
                return NotFound();
            }
           
            return View(defaultTopping);
        }

        // POST: DefaultTopping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit defaultTopping object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="defaultTopping"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PizzaName,ToppingName,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] DefaultTopping defaultTopping)
        {
            defaultTopping.AppUserId = User.UserGuidId();
            if (id != defaultTopping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.DefaultToppings.UpdateAsync(defaultTopping);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefaultToppingExists(defaultTopping.Id))
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
            
            return View(defaultTopping);
        }

        // GET: DefaultTopping/Delete/5
        /// <summary>
        /// delete defaultTopping object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var defaultTopping = await _bll.DefaultToppings
                .FirstOrDefaultAsync((Guid) id);

            if (defaultTopping == null)
            {
                return NotFound();
            }

            return View(defaultTopping);
        }

        // POST: DefaultTopping/Delete/5
        /// <summary>
        /// delete defaultTopping object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var defaultTopping = await _bll.DefaultToppings.FirstOrDefaultAsync(id);
            await _bll.DefaultToppings.RemoveAsync(defaultTopping);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefaultToppingExists(Guid id)
        {
            return _bll.DefaultToppings.ExistsAsync(id).Result;
        }

    }
}
