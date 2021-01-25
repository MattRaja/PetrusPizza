using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPizzaOrderRepositoryCustom: IPizzaOrderRepositoryCustom<PizzaOrder>
    {
    }

    public interface IPizzaOrderRepositoryCustom<TPizzaOrder>
    {
        Task<IEnumerable<TPizzaOrder>> GetAllAsync(Guid pizzaOrderId, Guid? userId = null, bool noTracking = true);
    }
    
}