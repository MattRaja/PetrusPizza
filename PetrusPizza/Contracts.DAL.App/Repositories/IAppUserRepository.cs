using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.Contracts.DAL.Base.Repositories;
using DAL.App.DTO;
using DAL.App.DTO.Identity;

namespace Contracts.DAL.App.Repositories
{
    public interface IAppUserRepository : IBaseRepository<AppUser>, IAppUserRepositoryCustom
    {
        Task<AppUser> GetFirstWithAllLocationsAsync(Guid id);
    }
}