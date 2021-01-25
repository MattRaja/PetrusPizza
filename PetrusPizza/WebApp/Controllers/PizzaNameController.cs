using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
using Domain.App;
using Extensions;
using Microsoft.AspNetCore.Authorization;
using PublicApi.DTO.v1;
using WebApp.ViewModels;
using Topping = ee.itcollege.mrajam.BLL.App.DTO.Topping;

namespace WebApp.Controllers
{
    /// <summary>
    /// Custom contoller for pizzaNames
    /// </summary>
    [Authorize]
    public class PizzaNameController : Controller
    {
        private readonly AppDbContext _ctx;
        private readonly IAppBLL _bll;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="bll"></param>
        public PizzaNameController(AppDbContext ctx, IAppBLL bll)
        {
            _ctx = ctx;
            _bll = bll;
        }

        // GET: PizzaName
        /// <summary>
        /// Show pizzaNames for the logged in user
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var defaultToppingsQuery = _bll.DefaultToppings.GetAllAsync().Result;
            var toppings = _bll.Toppings.GetAllAsync().Result;
            var pizzaNames = await _bll.PizzaNames.GetAllAsyncWithDefaultToppings(defaultToppingsQuery, toppings);
            foreach (var i in pizzaNames)
            {
                foreach (var t in i.DefaultToppings)
                {
                    
              
                }
            }
            return View(pizzaNames);
        }

        // GET: PizzaName/Details/5
        /// <summary>
        /// get pizzaName details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaName = await _bll.PizzaNames
                //.Include(p => p.AppUser)
                //.Include(p => p.NameOfPizza)
                //.Include(p => p.Price)
                //.Include(p => p.DefaultToppings)
                .FirstOrDefaultAsync((Guid) id);
            if (pizzaName == null)
            {
                return NotFound();
            }

            return View(pizzaName);
        }

        // GET: PizzaName/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var toppings = _bll.Toppings.GetAllAsync().Result.ToList();
            var dto = new PublicApi.DTO.v1.PizzaNameCreateEditDTO()
            {
                ToppingList = toppings
            };
            
            return View(dto);
        }

        


        // POST: PizzaName/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// create pizzaName object
        /// </summary>
        /// <param name="pizzaName"></param>
        /// <returns>form</returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NameOfPizza,Price,AppUserId,DefaultToppingsOut,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PublicApi.DTO.v1.PizzaNameCreateEditDTO pizzaName)
        {
            
                pizzaName.Id = Guid.NewGuid();
                pizzaName.AppUserId = User.UserGuidId();
                var bllPizzaName = new ee.itcollege.mrajam.BLL.App.DTO.PizzaName()
                {
                    Id = pizzaName.Id,
                    AppUserId = pizzaName.AppUserId,
                    Price = pizzaName.Price.ToString().Trim(),
                    NameOfPizza = pizzaName.NameOfPizza.Trim(),
                    DefaultToppings = null!
                };
                await _bll.PizzaNames.AddAndUpdateAsync(bllPizzaName);
                
                foreach (var defaultTopping in pizzaName.DefaultToppingsOut)
                {
                    var topping = _bll.Toppings.GetAllAsync().Result.First(a => a.ToppingName == defaultTopping);
                    await _bll.DefaultToppings.AddAndUpdateAsync(pizzaName, topping);
                }
                return RedirectToAction(nameof(Index));

        }

        // GET: PizzaName/Edit/5
        /// <summary>
        /// edit pizzaName object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
           

            if (id == null)
            {
                return NotFound();
            }

            var pizzaName = _bll.PizzaNames.FirstOrDefaultAsync(id).Result;

            if (pizzaName == null)
            {
                return NotFound();
            }
            else
            {
                var defaultToppingsQuery = _bll.DefaultToppings.GetAllAsync().Result
                    .Where(a => a.PizzaNameId == id.ToString());
                var toppingsQuery = _bll.Toppings.GetAllAsync().Result.ToList();
                
                var dto = _bll.PizzaNames.PrepareEditDTO(pizzaName, defaultToppingsQuery, toppingsQuery);
                return View(dto);
            }
        }

        // POST: PizzaName/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// edit pizzaName object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pizzaName"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("NameOfPizza,Price,AppUserId,DefaultToppingsOut,DefaultToppingsIn,Id,CreatedBy,CreatedAt,ChangedBy,ChangedAt")] PublicApi.DTO.v1.PizzaNameCreateEditDTO pizzaName)
        {
            
            if (id != pizzaName.Id)
            {
                return NotFound();
            }
            try
            {
                var bllPizzaName = new ee.itcollege.mrajam.BLL.App.DTO.PizzaName()
                {
                    Id = pizzaName.Id,
                    AppUserId = pizzaName.AppUserId,
                    Price = pizzaName.Price.ToString(CultureInfo.InvariantCulture).Trim(),
                    NameOfPizza = pizzaName.NameOfPizza.Trim(),
                    DefaultToppings = null!,
                    CreatedAt = pizzaName.CreatedAt,
                    CreatedBy = pizzaName.CreatedBy
                };
                await _bll.PizzaNames.UpdateAsync(bllPizzaName);

                var defaultToppingsIn = new List<string>();
                var defaultToppingsQuery = _bll.DefaultToppings.GetAllAsync().Result
                    .Where(a => a.PizzaNameId == id.ToString());
                var toppingsQuery = _bll.Toppings.GetAllAsync().Result;
                foreach (var defaultTopping in defaultToppingsQuery)
                {
                    var topping = toppingsQuery.First(a => a.Id.ToString() == defaultTopping.ToppingId);
                    defaultToppingsIn.Add(topping.ToppingName);
                }
                var defaultToppingsToRemove = defaultToppingsIn.Except(pizzaName.DefaultToppingsOut);
                var defaultToppingsToAdd = pizzaName.DefaultToppingsOut.Except(defaultToppingsIn);
                var defaultToppings = _bll.DefaultToppings.GetAllAsync().Result;
                foreach (var removable in defaultToppingsToRemove)
                {
                   
                    var toppingId = toppingsQuery.First(a => a.ToppingName == removable).Id;
                    var removableId = defaultToppings.First(a => a.ToppingId == toppingId.ToString()).Id;
                    await _bll.DefaultToppings.RemoveAsync(removableId);
                }
                foreach (var addable in defaultToppingsToAdd)
                {
                    var toppingId = toppingsQuery.First(a => a.ToppingName == addable).Id;
                    var defaultToppingDTO = new ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping()
                    {
                        Id = Guid.NewGuid(),
                        PizzaNameId = pizzaName.Id.ToString(),
                        AppUserId = pizzaName.AppUserId,
                        Price = pizzaName.Price.ToString(CultureInfo.InvariantCulture).Trim(),
                        ToppingId = toppingId.ToString()
                    };
                    await _bll.DefaultToppings.AddAndUpdateAsync(defaultToppingDTO);
                }
                    
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaNameExists(pizzaName.Id))
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

        // GET: PizzaName/Delete/5
        /// <summary>
        /// delete pizzaName object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pizzaName = await _bll.PizzaNames
                .FirstOrDefaultAsync((Guid) id);

            if (pizzaName == null)
            {
                return NotFound();
            }

            return View(pizzaName);
        }

        // POST: PizzaName/Delete/5
        /// <summary>
        /// delete pizzaName object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var pizzaName = await _bll.PizzaNames.FirstOrDefaultAsync(id);
            await _bll.PizzaNames.RemoveAsync(pizzaName);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaNameExists(Guid id)
        {
            return _bll.PizzaNames.ExistsAsync(id).Result;
        }

    }
}
