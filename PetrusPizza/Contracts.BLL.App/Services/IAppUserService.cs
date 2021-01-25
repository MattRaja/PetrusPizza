using System;
using System.Threading.Tasks;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.BLL.Base.Services;
using Contracts.DAL.App.Repositories;

namespace Contracts.BLL.App.Services
{
    public interface IAppUserService : IBaseEntityService<AppUser>, IAppUserRepositoryCustom<AppUser>
    {
        Task<AppUser> AddAndUpdateAsync(AppUser appUser);
    }

}