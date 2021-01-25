using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IBalanceRepositoryCustom: IBalanceRepositoryCustom<Balance>
    {
    }

    public interface IBalanceRepositoryCustom<TBalance>
    {
        Task<IEnumerable<TBalance>> GetAllAsync(Guid balanceId, Guid? userId = null, bool noTracking = true);
    }
    
}