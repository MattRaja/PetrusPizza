using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPizzaSizeRepositoryCustom: IPizzaSizeRepositoryCustom<PizzaSize>
    {
    }

    public interface IPizzaSizeRepositoryCustom<TPizzaSize>
    {
        Task<IEnumerable<TPizzaSize>> GetAllAsync(Guid pizzaSizeId, Guid? userId = null, bool noTracking = true);
    }
    
}