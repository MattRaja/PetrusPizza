using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using BLL.App.Mappers;
using ee.itcollege.mrajam.BLL.Base.Services;
using Contracts.BLL.App.Mappers;
using Contracts.BLL.App.Services;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF;

namespace BLL.App.Services
{
    public class OrderService :
        BaseEntityService<IAppUnitOfWork, IOrderRepository, IOrderServiceMapper, DAL.App.DTO.Order,
            Order>, IOrderService
    {
        public OrderService(IAppUnitOfWork uow) : base(uow, uow.Orders, new OrderServiceMapper())
        {
        }
        
        public Task<IEnumerable<Order>> GetAllAsync(Guid appUserId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task AddAndUpdateAsync(Order order)
        {
            var mapper = new OrderServiceMapper();
            var dalOrder = mapper.MapOrderBLLDTO(order);
            UOW.Orders.Add(dalOrder);
            await UOW.SaveChangesAsync();
        }
    }
}
