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
using PublicApi.DTO.v1;

namespace BLL.App.Services
{
    public class DefaultToppingService :
        BaseEntityService<IAppUnitOfWork, IDefaultToppingRepository, IDefaultToppingServiceMapper, DAL.App.DTO.DefaultTopping,
            DefaultTopping>, IDefaultToppingService
    {
        public DefaultToppingService(IAppUnitOfWork uow) : base(uow, uow.DefaultToppings, new DefaultToppingServiceMapper())
        {
        }
        
        public Task<IEnumerable<DefaultTopping>> GetAllAsync(Guid appUserId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
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

        public async Task AddAndUpdateAsync(PizzaNameCreateEditDTO pizzaName, Topping topping)
        {
            var defaultToppingDTO = new ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping()
            {
                Id = Guid.NewGuid(),
                PizzaNameId = pizzaName.Id.ToString(),
                AppUserId = pizzaName.AppUserId,
                Price = pizzaName.Price.ToString(),
                ToppingId = topping.Id.ToString(),
            };
            var mapper = new DefaultToppingServiceMapper();
            var dalDefaultTopping = mapper.MapDefaultToppingBLLDTO(defaultToppingDTO);
            UOW.DefaultToppings.Add(dalDefaultTopping);
            await UOW.SaveChangesAsync();
        }

        public async Task AddAndUpdateAsync(DefaultTopping defaultTopping)
        {
            var mapper = new DefaultToppingServiceMapper();
            var dalDefaultTopping = mapper.MapDefaultToppingBLLDTO(defaultTopping);
            UOW.DefaultToppings.Add(dalDefaultTopping);
            await UOW.SaveChangesAsync();
        }

        public async Task UpdateAsync(DefaultTopping defaultTopping)
        {
            var mapper = new DefaultToppingServiceMapper();
            var dalDefaultTopping = mapper.MapDefaultToppingBLLDTO(defaultTopping);
            var defaultToppings = UOW.DefaultToppings.GetAllAsync().Result;
            await UOW.DefaultToppings.UpdateAsync(dalDefaultTopping);
            await UOW.SaveChangesAsync();
        }

        public Task UpdateAsync(Topping defaultToppingIds)
        {
            throw new NotImplementedException();
        }
        
    }
}
