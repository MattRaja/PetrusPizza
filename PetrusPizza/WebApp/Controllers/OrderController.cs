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
    /// Custom contoller for orders
    /// </summary>
    [Authorize]
    public class OrderController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public OrderController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: Order
        /// <summary>
        /// Show orders for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var orders = await _bll.Orders.GetAllAsync();
            return View(orders);
        }

        // GET: Order/Details/5
        /// <summary>
        /// get order details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _bll.Orders
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create order object
        /// </summary>
        /// <param name="order"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDate,OrderNr,SumWithoutVAT,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Order order)
        {
            
            if (ModelState.IsValid)
            {
                order.Id = Guid.NewGuid();
                order.AppUserId = User.UserGuidId();
                _bll.Orders.Add(order);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", order.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", order.GpsSessionTypeId);
            return View();

        }

        // GET: Order/Edit/5
        /// <summary>
        /// edit order object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _bll.Orders.FirstOrDefaultAsync((Guid) id);
            if (order == null)
            {
                return NotFound();
            }
           
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit order object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrderDate,OrderNr,SumWithoutVAT,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] Order order)
        {
            order.AppUserId = User.UserGuidId();
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.Orders.UpdateAsync(order);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            
            return View(order);
        }

        // GET: Order/Delete/5
        /// <summary>
        /// delete order object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _bll.Orders
                .FirstOrDefaultAsync((Guid) id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        /// <summary>
        /// delete order object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var order = await _bll.Orders.FirstOrDefaultAsync(id);
            await _bll.Orders.RemoveAsync(order);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(Guid id)
        {
            return _bll.Orders.ExistsAsync(id).Result;
        }

    }
}
