using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using BLL.App.Mappers;
using ee.itcollege.mrajam.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using PublicApi.DTO.v1;

namespace BLL.App.Services
{
    public class PizzaNameService :
        BaseEntityService<IAppUnitOfWork, IPizzaNameRepository, IPizzaNameServiceMapper, DAL.App.DTO.PizzaName,
            PizzaName>, IPizzaNameService
    {
        public PizzaNameService(IAppUnitOfWork uow) : base(uow, uow.PizzaNames, new PizzaNameServiceMapper())
        {
        }

        public virtual async Task<IEnumerable<PizzaNameDTO>> GetAllAsyncWithDefaultToppings(
            IEnumerable<DefaultTopping> defaultToppingsQuery, IEnumerable<Topping> toppings,
            object? userId = null, bool noTracking = true)
        {
            var pizzaNames = await Repository.GetAllAsync(userId, noTracking);
            var pizzaNamesDTOList = new List<PizzaNameDTO>();
            foreach (var pizzaName in pizzaNames)
            {
              ;
                var defaultToppings = new List<string>();
                var defaultToppingQuery = defaultToppingsQuery.Where(a => a.PizzaNameId == pizzaName.Id.ToString());
                foreach (var defaultTopping in defaultToppingQuery)
                {
                    Console.WriteLine(defaultTopping.ToppingId);
                    var topping = toppings.First(a => a.Id.ToString() == defaultTopping.ToppingId);
                  
                    defaultToppings.Add(topping.ToppingName);
                }

                var pizzaNameDTO = new PizzaNameDTO()
                {
                    Id = pizzaName.Id,
                    Price = pizzaName.Price,
                    AppUserId = pizzaName.AppUserId,
                    NameOfPizza = pizzaName.NameOfPizza,
                    DefaultToppings = defaultToppings
                };
                pizzaNamesDTOList.Add(pizzaNameDTO);
            }
            return pizzaNamesDTOList;
        }

        public PublicApi.DTO.v1.PizzaNameCreateEditDTO PrepareEditDTO(PizzaName pizzaName, IEnumerable<DefaultTopping> defaultToppingsQuery, IEnumerable<Topping> toppingsQuery,
            object? userId = null, bool noTracking = true)
        {
            var defaultToppings = new List<string>();
            foreach (var defaultTopping in defaultToppingsQuery)
            {
                var topping = toppingsQuery.First(a => a.Id.ToString() == defaultTopping.ToppingId);
                defaultToppings.Add(topping.ToppingName);
            }
                
            var dto = new PublicApi.DTO.v1.PizzaNameCreateEditDTO()
            {
                NameOfPizza = pizzaName.NameOfPizza,
                Price = decimal.Parse(pizzaName.Price),
                ToppingList = toppingsQuery.ToList(),
                DefaultToppingsIn = defaultToppings,
                AppUserId = pizzaName.AppUserId,
                CreatedAt = pizzaName.CreatedAt,
                CreatedBy = pizzaName.CreatedBy
            };
            return dto;
        }

        public IEnumerable<Topping> GetToppings()
        {
            var toppings = UOW.Toppings.GetAllAsync().Result.Select(e => Mapper.MapToppings(e));
            return toppings;
        }

        public async Task UpdateAsync(PizzaName pizzaName)
        {
            var mapper = new PizzaNameServiceMapper();
            var dalPizzaName = mapper.MapPizzaNameBLLDTO(pizzaName);
            await UOW.PizzaNames.UpdateAsync(dalPizzaName);
            await UOW.SaveChangesAsync();
        }

        public async Task AddAndUpdateAsync(PizzaName pizzaName)
        {
          
            var mapper = new PizzaNameServiceMapper();
            var dalPizzaName = mapper.MapPizzaNameBLLDTO(pizzaName);
            UOW.PizzaNames.Add(dalPizzaName);
            await UOW.SaveChangesAsync();
        }

        public Task<IEnumerable<PizzaName>> GetAllAsync(Guid pizzaNameId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
