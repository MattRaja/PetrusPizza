using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IOrderRowRepositoryCustom: IOrderRowRepositoryCustom<OrderRow>
    {
    }

    public interface IOrderRowRepositoryCustom<TOrderRow>
    {
        Task<IEnumerable<TOrderRow>> GetAllAsync(Guid orderRowId, Guid? userId = null, bool noTracking = true);
    }
    
}