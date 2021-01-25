using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.App.EF.Mappers;
using ee.itcollege.mrajam.DAL.Base.EF.Repositories;
using ee.itcollege.mrajam.DAL.Base.Mappers;
using Domain.App.Identity;
using Microsoft.EntityFrameworkCore;


namespace DAL.App.EF.Repositories
{
    public class ToppingRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.Topping, DAL.App.DTO.Topping>,
        IToppingRepository
    {
        public ToppingRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.Topping, DTO.Topping>())
        {
        }

        public override async Task<IEnumerable<Topping>> GetAllAsync(object? userId = null, bool noTracking = true)
        {
            var query = PrepareQuery(userId, noTracking);
            query = query
                //.Include(g => g.AppUser)
                //.Include(g => g.Price)
                //.Include(g => g.ToppingName)
                .OrderBy(a => a.ToppingName);
            var domainItems = await query.ToListAsync();
            var result = domainItems.Select(e => Mapper.Map(e));
            return result;
        }
        
        
        // public async Task<Topping> GetFirstWithAllLocationsAsync(Guid id)
        // {
        //     var domainTopping = await RepoDbSet.AsNoTracking()
        //         .FirstOrDefaultAsync(a => a.Id == id);
        //
        //     domainTopping.GpsLocations = await RepoDbContext.GpsLocations.AsNoTracking()
        //         .Where(l => l.ToppingId == id)
        //         .OrderByDescending(l => l.RecordedAt)
        //         .ToListAsync();
        //
        //     return Mapper.Map(domainTopping);
        // }
        public Task<IEnumerable<Topping>> GetAllAsync(Guid balanceId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Topping> GetFirstWithAllLocationsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
