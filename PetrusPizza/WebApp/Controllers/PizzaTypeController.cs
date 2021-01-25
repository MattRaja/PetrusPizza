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
    /// Custom contoller for pizzaTypes
    /// </summary>
    [Authorize]
    public class PizzaTypeController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public PizzaTypeController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: PizzaType
        /// <summary>
        /// Show pizzaTypes for the logged in user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var pizzaTypes = await _bll.PizzaTypes.GetAllAsync();
            return View(pizzaTypes);
        }

        // GET: PizzaType/Details/5
        /// <summary>
        /// get pizzaType details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaType = await _bll.PizzaTypes
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (pizzaType == null)
            {
                return NotFound();
            }

            return View(pizzaType);
        }

        // GET: PizzaType/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: PizzaType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create pizzaType object
        /// </summary>
        /// <param name="pizzaType"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PizzaTypeName,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PizzaType pizzaType)
        {
            
            if (ModelState.IsValid)
            {
                pizzaType.Id = Guid.NewGuid();
                pizzaType.AppUserId = User.UserGuidId();
                _bll.PizzaTypes.Add(pizzaType);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", pizzaType.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", pizzaType.GpsSessionTypeId);
            return View();

        }

        // GET: PizzaType/Edit/5
        /// <summary>
        /// edit pizzaType object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaType = await _bll.PizzaTypes.FirstOrDefaultAsync((Guid) id);
            if (pizzaType == null)
            {
                return NotFound();
            }
           
            return View(pizzaType);
        }

        // POST: PizzaType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit pizzaType object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pizzaType"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PizzaTypeName,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PizzaType pizzaType)
        {
            pizzaType.AppUserId = User.UserGuidId();
            if (id != pizzaType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.PizzaTypes.UpdateAsync(pizzaType);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaTypeExists(pizzaType.Id))
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
            
            return View(pizzaType);
        }

        // GET: PizzaType/Delete/5
        /// <summary>
        /// delete pizzaType object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaType = await _bll.PizzaTypes
                .FirstOrDefaultAsync((Guid) id);

            if (pizzaType == null)
            {
                return NotFound();
            }

            return View(pizzaType);
        }

        // POST: PizzaType/Delete/5
        /// <summary>
        /// delete pizzaType object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pizzaType = await _bll.PizzaTypes.FirstOrDefaultAsync(id);
            await _bll.PizzaTypes.RemoveAsync(pizzaType);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaTypeExists(Guid id)
        {
            return _bll.PizzaTypes.ExistsAsync(id).Result;
        }

    }
}
