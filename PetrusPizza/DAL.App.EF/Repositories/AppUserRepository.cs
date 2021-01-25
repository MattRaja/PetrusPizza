using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.DTO.Identity;
using DAL.App.EF.Mappers;
using ee.itcollege.mrajam.DAL.Base.EF.Repositories;
using ee.itcollege.mrajam.DAL.Base.Mappers;
using Microsoft.EntityFrameworkCore;



namespace DAL.App.EF.Repositories
{
    public class AppUserRepository :
        EFBaseRepository<AppDbContext, Domain.App.Identity.AppUser, Domain.App.Identity.AppUser, DAL.App.DTO.Identity.AppUser>,
        IAppUserRepository
    {
        public AppUserRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.Identity.AppUser, DTO.Identity.AppUser>())
        {
        }

        // public async Task<IEnumerable<DAL.App.DTO.Identity.AppUser>> AllAsync(Guid? userId = null)
        // {
        //     if (userId == null)
        //     {
        //         return await base.AllAsync(); // base is not actually needed, using it for clarity
        //     }
        //
        //     return (await RepoDbSet.Where(o => o.Id == userId)
        //         .ToListAsync()).Select(domainEntity => Mapper.Map(domainEntity));
        //
        // }
        //
        // public async Task<AppUser> FirstOrDefaultAsync(Guid id, Guid? userId = null)
        // {
        //     var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
        //     if (userId != null)
        //     {
        //         query = query.Where(a => a.Id == userId);
        //     }
        //
        //     return Mapper.Map(await query.FirstOrDefaultAsync());
        //
        // }
        //
        // public async Task<bool> ExistsAsync(Guid id, Guid? userId = null)
        // {
        //     if (userId == null)
        //     {
        //         return await RepoDbSet.AnyAsync(a => a.Id == id);
        //     }
        //
        //     return await RepoDbSet.AnyAsync(a => a.Id == id && a.Id == userId);
        // }
        //
        // public async Task DeleteAsync(Guid id, Guid? userId = null)
        // {
        //     var appUser = await FirstOrDefaultAsync(id, userId);
        //     base.Remove(appUser);
        // }
        //
        // // we need to do it on database level, to avoid unnecessary queries to db 
        // public async Task<IEnumerable<AppUserDTO>> DTOAllAsync(Guid? userId = null)
        // {
        //     var query = RepoDbSet.AsQueryable();
        //     if (userId != null)
        //     {
        //         query = query.Where(o => o.Id == userId);
        //     }
        //     return await query
        //         .Select(o => new AppUserDTO()
        //         {
        //             Id = o.Id,
        //             FirstName = o.FirstName,
        //             LastName = o.LastName,
        //             MoneyInWallet = o.MoneyInWallet,
        //             Payments = o.Payments,
        //             Orders = o.Orders,
        //             AppUsers = o.AppUsers
        //         })
        //         .ToListAsync();
        // }
        //
        // public async Task<AppUserDTO> DTOFirstOrDefaultAsync(Guid id, Guid? userId = null)
        // {
        //     var query = RepoDbSet.Where(a => a.Id == id).AsQueryable();
        //     if (userId != null)
        //     {
        //         query = query.Where(a => a.Id == userId);
        //     }
        //
        //     var appUserDTO = await query.Select(o => new AppUserDTO()
        //     {
        //         Id = o.Id,
        //         FirstName = o.FirstName,
        //         LastName = o.LastName,
        //         MoneyInWallet = o.MoneyInWallet,
        //         Payments = o.Payments,
        //         Orders = o.Orders,
        //         AppUsers = o.AppUsers
        //     }).FirstOrDefaultAsync();
        //
        //     return appUserDTO;
        // }
        public Task<IEnumerable<AppUser>> GetAllAsync(Guid appUserId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetFirstWithAllLocationsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
