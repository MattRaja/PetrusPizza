using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IPaymentRepositoryCustom: IPaymentRepositoryCustom<Payment>
    {
    }

    public interface IPaymentRepositoryCustom<TPayment>
    {
        Task<IEnumerable<TPayment>> GetAllAsync(Guid paymentId, Guid? userId = null, bool noTracking = true);
    }
    
}