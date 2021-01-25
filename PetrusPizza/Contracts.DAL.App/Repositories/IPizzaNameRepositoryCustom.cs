using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPizzaNameRepositoryCustom: IPizzaNameRepositoryCustom<PizzaName>
    {
    }

    public interface IPizzaNameRepositoryCustom<TPizzaName>
    {
        Task<IEnumerable<TPizzaName>> GetAllAsync(Guid pizzaNameId, Guid? userId = null, bool noTracking = true);
    }
    
}