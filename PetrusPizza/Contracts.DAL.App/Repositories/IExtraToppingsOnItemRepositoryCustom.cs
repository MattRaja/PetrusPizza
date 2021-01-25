using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IExtraToppingsOnItemRepositoryCustom: IExtraToppingsOnItemRepositoryCustom<ExtraToppingsOnItem>
    {
    }

    public interface IExtraToppingsOnItemRepositoryCustom<TExtraToppingsOnItem>
    {
        Task<IEnumerable<TExtraToppingsOnItem>> GetAllAsync(Guid extraToppingsOnItemId, Guid? userId = null, bool noTracking = true);
    }
    
}