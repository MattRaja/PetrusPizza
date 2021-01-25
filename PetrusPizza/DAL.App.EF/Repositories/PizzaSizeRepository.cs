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
    public class PizzaSizeRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.PizzaSize, DAL.App.DTO.PizzaSize>,
        IPizzaSizeRepository
    {
        public PizzaSizeRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.PizzaSize, DTO.PizzaSize>())
        {
        }

        // public override async Task<IEnumerable<PizzaSize>> GetAllAsync(object? userId = null, bool noTracking = true)
        // {
        //     var query = PrepareQuery(userId, noTracking);
        //     query = query
        //         .Include(g => g.AppUser)
        //         .Include(g => g.PizzaSizeType)
        //         .ThenInclude(g => g!.Name)
        //         .ThenInclude(t => t!.Translations)
        //         .OrderByDescending(a => a.RecordedAt);
        //     var domainItems = await query.ToListAsync();
        //     var result = domainItems.Select(e => Mapper.Map(e));
        //     return result;
        // }
        //
        // public virtual async Task<IEnumerable<PizzaSizeView>> GetAllForViewAsync(int minLocationsCount = 10,
        //     double minDuration = 60, double minDistance = 10, DateTime? fromDateTime = null,
        //     DateTime? toDateTime = null)
        // {
        //     var query = RepoDbSet
        //         .Include(a => a.PizzaSizeType)
        //         .ThenInclude(a => a!.Name)
        //         .ThenInclude(a => a!.Translations)
        //         .Where(a => a.GpsLocations!.Count >= minLocationsCount && a.Duration >= minDuration &&
        //                     a.Distance >= minDistance);
        //     if (fromDateTime != null)
        //     {
        //         query = query.Where(a => a.RecordedAt >= fromDateTime);
        //     }
        //
        //     if (toDateTime != null)
        //     {
        //         query = query.Where(a => a.RecordedAt <= toDateTime);
        //     }
        //
        //     query = query
        //         .OrderByDescending(a => a.RecordedAt);
        //     var result = await query
        //         .Select(a => new PizzaSizeView()
        //         {
        //             Id = a.Id,
        //             Name = a.Name,
        //             Description = a.Description,
        //             RecordedAt = a.RecordedAt,
        //             Duration = a.Duration,
        //             Speed = a.Speed,
        //             Distance = a.Distance,
        //             Climb = a.Climb,
        //             Descent = a.Descent,
        //             MinSpeed = a.PaceMin,
        //             MaxSpeed = a.PaceMax,
        //             GpsLocationsCount = a.GpsLocations!.Count,
        //             PizzaSizeType = a.PizzaSizeType!.Name,
        //             UserFirstLastName = a.AppUser!.FirstName + " " + a.AppUser!.LastName,
        //             UserId = a.AppUserId,
        //         }).ToListAsync();
        //
        //     return result;
        // }
        //
        // public async Task<PizzaSize> GetFirstWithAllLocationsAsync(Guid id)
        // {
        //     var domainPizzaSize = await RepoDbSet.AsNoTracking()
        //         .FirstOrDefaultAsync(a => a.Id == id);
        //
        //     domainPizzaSize.GpsLocations = await RepoDbContext.GpsLocations.AsNoTracking()
        //         .Where(l => l.PizzaSizeId == id)
        //         .OrderByDescending(l => l.RecordedAt)
        //         .ToListAsync();
        //
        //     return Mapper.Map(domainPizzaSize);
        // }
        public Task<IEnumerable<PizzaSize>> GetAllAsync(Guid balanceId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<PizzaSize> GetFirstWithAllLocationsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
