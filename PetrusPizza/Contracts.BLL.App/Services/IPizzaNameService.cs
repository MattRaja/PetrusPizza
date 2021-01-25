using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;
using PublicApi.DTO.v1;

namespace Contracts.BLL.App.Services
{
    public interface IPizzaNameService : IBaseEntityService<PizzaName>, IPizzaNameRepositoryCustom<PizzaName>
    {
        //Task<PizzaName> AddAndUpdateAsync(PizzaName pizzaName);
        Task AddAndUpdateAsync(PizzaName pizzaName);
        Task UpdateAsync(PizzaName pizzaName);
        Task<IEnumerable<PizzaNameDTO>> GetAllAsyncWithDefaultToppings(IEnumerable<DefaultTopping> defaultToppingsQuery, IEnumerable<Topping> toppings,
            object? userId = null, bool noTracking = true);

        PublicApi.DTO.v1.PizzaNameCreateEditDTO PrepareEditDTO(PizzaName pizzaName, IEnumerable<DefaultTopping> defaultToppingsQuery, IEnumerable<Topping> toppings,
            object? userId = null, bool noTracking = true);
    }

}