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
    /// Custom contoller for pizzaSizes
    /// </summary>
    [Authorize]
    public class PizzaSizeController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public PizzaSizeController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: PizzaSize
        /// <summary>
        /// Show pizzaSizes for the logged in user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var pizzaSizes = await _bll.PizzaSizes.GetAllAsync();
            return View(pizzaSizes);
        }

        // GET: PizzaSize/Details/5
        /// <summary>
        /// get pizzaSize details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaSize = await _bll.PizzaSizes
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (pizzaSize == null)
            {
                return NotFound();
            }

            return View(pizzaSize);
        }

        // GET: PizzaSize/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: PizzaSize/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create pizzaSize object
        /// </summary>
        /// <param name="pizzaSize"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PizzaSizeName,Price,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PizzaSize pizzaSize)
        {
            
            if (ModelState.IsValid)
            {
                pizzaSize.Id = Guid.NewGuid();
                pizzaSize.AppUserId = User.UserGuidId();
                _bll.PizzaSizes.Add(pizzaSize);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", pizzaSize.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", pizzaSize.GpsSessionTypeId);
            return View();

        }

        // GET: PizzaSize/Edit/5
        /// <summary>
        /// edit pizzaSize object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaSize = await _bll.PizzaSizes.FirstOrDefaultAsync((Guid) id);
            if (pizzaSize == null)
            {
                return NotFound();
            }
           
            return View(pizzaSize);
        }

        // POST: PizzaSize/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit pizzaSize object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pizzaSize"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PizzaSizeName,Price,UserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PizzaSize pizzaSize)
        {
            pizzaSize.AppUserId = User.UserGuidId();
            if (id != pizzaSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.PizzaSizes.UpdateAsync(pizzaSize);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaSizeExists(pizzaSize.Id))
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
            
            return View(pizzaSize);
        }

        // GET: PizzaSize/Delete/5
        /// <summary>
        /// delete pizzaSize object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaSize = await _bll.PizzaSizes
                .FirstOrDefaultAsync((Guid) id);

            if (pizzaSize == null)
            {
                return NotFound();
            }

            return View(pizzaSize);
        }

        // POST: PizzaSize/Delete/5
        /// <summary>
        /// delete pizzaSize object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pizzaSize = await _bll.PizzaSizes.FirstOrDefaultAsync(id);
            await _bll.PizzaSizes.RemoveAsync(pizzaSize);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaSizeExists(Guid id)
        {
            return _bll.PizzaSizes.ExistsAsync(id).Result;
        }

    }
}
