using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories
{
    public interface IExtraToppingsOnItemRepository : IBaseRepository<ExtraToppingsOnItem>, IExtraToppingsOnItemRepositoryCustom
    {
        Task<ExtraToppingsOnItem> GetFirstWithAllLocationsAsync(Guid id);
    }
}