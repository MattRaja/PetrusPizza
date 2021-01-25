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
    /// Custom contoller for itemRows
    /// </summary>
    [Authorize]
    public class ItemRowController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public ItemRowController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: ItemRow
        /// <summary>
        /// Show itemRows for the logged in user
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
            var itemRows = await _bll.ItemRows.GetAllAsync();
            return View(itemRows);
        }

        // GET: ItemRow/Details/5
        /// <summary>
        /// get itemRow details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRow = await _bll.ItemRows
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (itemRow == null)
            {
                return NotFound();
            }

            return View(itemRow);
        }

        // GET: ItemRow/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        


        // POST: ItemRow/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create itemRow object
        /// </summary>
        /// <param name="itemRow"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] ItemRow itemRow)
        {
            
            if (ModelState.IsValid)
            {
                itemRow.Id = Guid.NewGuid();
                itemRow.AppUserId = User.UserGuidId();
                _bll.ItemRows.Add(itemRow);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // ViewData["AppUserId"] = new SelectList(_ctx.Users, "Id", "FirstName", itemRow.AppUserId);
            // ViewData["GpsSessionTypeId"] =
            //     new SelectList(_ctx.GpsSessionTypes, "Id", "Id", itemRow.GpsSessionTypeId);
            return View();

        }

        // GET: ItemRow/Edit/5
        /// <summary>
        /// edit itemRow object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRow = await _bll.ItemRows.FirstOrDefaultAsync((Guid) id);
            if (itemRow == null)
            {
                return NotFound();
            }
           
            return View(itemRow);
        }

        // POST: ItemRow/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit itemRow object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemRow"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Amount,AppUserId,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] ItemRow itemRow)
        {
            itemRow.AppUserId = User.UserGuidId();
            if (id != itemRow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                try
                {
                    await _bll.ItemRows.UpdateAsync(itemRow);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemRowExists(itemRow.Id))
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
            
            return View(itemRow);
        }

        // GET: ItemRow/Delete/5
        /// <summary>
        /// delete itemRow object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemRow = await _bll.ItemRows
                .FirstOrDefaultAsync((Guid) id);

            if (itemRow == null)
            {
                return NotFound();
            }

            return View(itemRow);
        }

        // POST: ItemRow/Delete/5
        /// <summary>
        /// delete itemRow object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var itemRow = await _bll.ItemRows.FirstOrDefaultAsync(id);
            await _bll.ItemRows.RemoveAsync(itemRow);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemRowExists(Guid id)
        {
            return _bll.ItemRows.ExistsAsync(id).Result;
        }

    }
}
