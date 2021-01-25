using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IOrderRepositoryCustom: IOrderRepositoryCustom<Order>
    {
    }

    public interface IOrderRepositoryCustom<TOrder>
    {
        Task<IEnumerable<TOrder>> GetAllAsync(Guid orderId, Guid? userId = null, bool noTracking = true);
    }
    
}