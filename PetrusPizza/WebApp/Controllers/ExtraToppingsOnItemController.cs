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
    /// Custom contoller for extraToppingsOnItems
    /// </summary>
    [Authorize]
    public class ExtraToppingsOnItemController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public ExtraToppingsOnItemController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: ExtraToppingsOnItem
        /// <summary>
        /// Show extraToppingsOnItems for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var extraToppingsOnItems = await _bll.ExtraToppingsOnItems.GetAllAsync();
            return View(extraToppingsOnItems);
        }

        // GET: ExtraToppingsOnItem/Details/5
        /// <summary>
        /// get extraToppingsOnItem details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraToppingsOnItem = await _bll.ExtraToppingsOnItems
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (extraToppingsOnItem == null)
            {
                return NotFound();
            }

            return View(extraToppingsOnItem);
        }

        // GET: ExtraToppingsOnItem/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: ExtraToppingsOnItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create extraToppingsOnItem object
        /// </summary>
        /// <param name="extraToppingsOnItem"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToppingName,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] ExtraToppingsOnItem extraToppingsOnItem)
        {
            
            if (ModelState.IsValid)
            {
                extraToppingsOnItem.Id = Guid.NewGuid();
                extraToppingsOnItem.AppUserId = User.UserGuidId();
                _bll.ExtraToppingsOnItems.Add(extraToppingsOnItem);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", extraToppingsOnItem.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", extraToppingsOnItem.GpsSessionTypeId);
            return View();

        }

        // GET: ExtraToppingsOnItem/Edit/5
        /// <summary>
        /// edit extraToppingsOnItem object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraToppingsOnItem = await _bll.ExtraToppingsOnItems.FirstOrDefaultAsync((Guid) id);
            if (extraToppingsOnItem == null)
            {
                return NotFound();
            }
           
            return View(extraToppingsOnItem);
        }

        // POST: ExtraToppingsOnItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit extraToppingsOnItem object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="extraToppingsOnItem"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ToppingName,Price,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] ExtraToppingsOnItem extraToppingsOnItem)
        {
            extraToppingsOnItem.AppUserId = User.UserGuidId();
            if (id != extraToppingsOnItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.ExtraToppingsOnItems.UpdateAsync(extraToppingsOnItem);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExtraToppingsOnItemExists(extraToppingsOnItem.Id))
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
            
            return View(extraToppingsOnItem);
        }

        // GET: ExtraToppingsOnItem/Delete/5
        /// <summary>
        /// delete extraToppingsOnItem object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var extraToppingsOnItem = await _bll.ExtraToppingsOnItems
                .FirstOrDefaultAsync((Guid) id);

            if (extraToppingsOnItem == null)
            {
                return NotFound();
            }

            return View(extraToppingsOnItem);
        }

        // POST: ExtraToppingsOnItem/Delete/5
        /// <summary>
        /// delete extraToppingsOnItem object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var extraToppingsOnItem = await _bll.ExtraToppingsOnItems.FirstOrDefaultAsync(id);
            await _bll.ExtraToppingsOnItems.RemoveAsync(extraToppingsOnItem);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraToppingsOnItemExists(Guid id)
        {
            return _bll.ExtraToppingsOnItems.ExistsAsync(id).Result;
        }

    }
}
