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
    public class OrderRowService :
        BaseEntityService<IAppUnitOfWork, IOrderRowRepository, IOrderRowServiceMapper, DAL.App.DTO.OrderRow,
            OrderRow>, IOrderRowService
    {
        public OrderRowService(IAppUnitOfWork uow) : base(uow, uow.OrderRows, new OrderRowServiceMapper())
        {
        }
        
        public Task<IEnumerable<OrderRow>> GetAllAsync(Guid appUserId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task AddAndUpdateAsync(OrderRow orderRow)
        {
            var mapper = new OrderRowServiceMapper();
            var dalOrderRow = mapper.MapOrderRowBLLDTO(orderRow);
            UOW.OrderRows.Add(dalOrderRow);
            await UOW.SaveChangesAsync();
        }
    }
}
