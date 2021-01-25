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
    /// Custom contoller for orderRows
    /// </summary>
    [Authorize]
    public class OrderRowController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public OrderRowController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: OrderRow
        /// <summary>
        /// Show orderRows for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var orderRows = await _bll.OrderRows.GetAllAsync();
            return View(orderRows);
        }

        // GET: OrderRow/Details/5
        /// <summary>
        /// get orderRow details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRow = await _bll.OrderRows
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // GET: OrderRow/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: OrderRow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create orderRow object
        /// </summary>
        /// <param name="orderRow"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,Price,Sum,AppUserId,VAT,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] OrderRow orderRow)
        {
            
            if (ModelState.IsValid)
            {
                orderRow.Id = Guid.NewGuid();
                orderRow.AppUserId = User.UserGuidId();
                _bll.OrderRows.Add(orderRow);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", orderRow.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", orderRow.GpsSessionTypeId);
            return View();

        }

        // GET: OrderRow/Edit/5
        /// <summary>
        /// edit orderRow object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRow = await _bll.OrderRows.FirstOrDefaultAsync((Guid) id);
            if (orderRow == null)
            {
                return NotFound();
            }
           
            return View(orderRow);
        }

        // POST: OrderRow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit orderRow object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="orderRow"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,Price,Sum,AppUserId,VAT,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] OrderRow orderRow)
        {
            orderRow.AppUserId = User.UserGuidId();
            if (id != orderRow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.OrderRows.UpdateAsync(orderRow);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderRowExists(orderRow.Id))
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
            
            return View(orderRow);
        }

        // GET: OrderRow/Delete/5
        /// <summary>
        /// delete orderRow object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRow = await _bll.OrderRows
                .FirstOrDefaultAsync((Guid) id);

            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // POST: OrderRow/Delete/5
        /// <summary>
        /// delete orderRow object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var orderRow = await _bll.OrderRows.FirstOrDefaultAsync(id);
            await _bll.OrderRows.RemoveAsync(orderRow);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderRowExists(Guid id)
        {
            return _bll.OrderRows.ExistsAsync(id).Result;
        }

    }
}
