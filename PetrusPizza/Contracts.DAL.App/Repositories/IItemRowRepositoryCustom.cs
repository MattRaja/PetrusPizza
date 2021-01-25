using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IItemRowRepositoryCustom: IItemRowRepositoryCustom<ItemRow>
    {
    }

    public interface IItemRowRepositoryCustom<TItemRow>
    {
        Task<IEnumerable<TItemRow>> GetAllAsync(Guid itemRowId, Guid? userId = null, bool noTracking = true);
    }
    
}