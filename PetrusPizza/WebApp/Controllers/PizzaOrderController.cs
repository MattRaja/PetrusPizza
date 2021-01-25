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
    /// Custom contoller for pizzaOrders
    /// </summary>
    [Authorize]
    public class PizzaOrderController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public PizzaOrderController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: PizzaOrder
        /// <summary>
        /// Show pizzaOrders for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var pizzaOrders = await _bll.PizzaOrders.GetAllAsync();
            return View(pizzaOrders);
        }

        // GET: PizzaOrder/Details/5
        /// <summary>
        /// get pizzaOrder details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaOrder = await _bll.PizzaOrders
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (pizzaOrder == null)
            {
                return NotFound();
            }

            return View(pizzaOrder);
        }

        // GET: PizzaOrder/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: PizzaOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create pizzaOrder object
        /// </summary>
        /// <param name="pizzaOrder"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PizzaName,PizzaSize,PizzaType,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PizzaOrder pizzaOrder)
        {
            
            if (ModelState.IsValid)
            {
                pizzaOrder.Id = Guid.NewGuid();
                pizzaOrder.AppUserId = User.UserGuidId();
                _bll.PizzaOrders.Add(pizzaOrder);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", pizzaOrder.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", pizzaOrder.GpsSessionTypeId);
            return View();

        }

        // GET: PizzaOrder/Edit/5
        /// <summary>
        /// edit pizzaOrder object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaOrder = await _bll.PizzaOrders.FirstOrDefaultAsync((Guid) id);
            if (pizzaOrder == null)
            {
                return NotFound();
            }
           
            return View(pizzaOrder);
        }

        // POST: PizzaOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit pizzaOrder object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pizzaOrder"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PizzaName,PizzaSize,PizzaType,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PizzaOrder pizzaOrder)
        {
            pizzaOrder.AppUserId = User.UserGuidId();
            if (id != pizzaOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.PizzaOrders.UpdateAsync(pizzaOrder);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaOrderExists(pizzaOrder.Id))
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
            
            return View(pizzaOrder);
        }

        // GET: PizzaOrder/Delete/5
        /// <summary>
        /// delete pizzaOrder object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaOrder = await _bll.PizzaOrders
                .FirstOrDefaultAsync((Guid) id);

            if (pizzaOrder == null)
            {
                return NotFound();
            }

            return View(pizzaOrder);
        }

        // POST: PizzaOrder/Delete/5
        /// <summary>
        /// delete pizzaOrder object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pizzaOrder = await _bll.PizzaOrders.FirstOrDefaultAsync(id);
            await _bll.PizzaOrders.RemoveAsync(pizzaOrder);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaOrderExists(Guid id)
        {
            return _bll.PizzaOrders.ExistsAsync(id).Result;
        }

    }
}
