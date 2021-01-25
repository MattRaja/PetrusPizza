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
    public class ExtraToppingsOnItemRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.ExtraToppingsOnItem, DAL.App.DTO.ExtraToppingsOnItem>,
        IExtraToppingsOnItemRepository
    {
        public ExtraToppingsOnItemRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.ExtraToppingsOnItem, DTO.ExtraToppingsOnItem>())
        {
        }

        // public override async Task<IEnumerable<ExtraToppingsOnItem>> GetAllAsync(object? userId = null, bool noTracking = true)
        // {
        //     var query = PrepareQuery(userId, noTracking);
        //     query = query
        //         .Include(g => g.AppUser)
        //         .Include(g => g.ExtraToppingsOnItemType)
        //         .ThenInclude(g => g!.Name)
        //         .ThenInclude(t => t!.Translations)
        //         .OrderByDescending(a => a.RecordedAt);
        //     var domainItems = await query.ToListAsync();
        //     var result = domainItems.Select(e => Mapper.Map(e));
        //     return result;
        // }
        //
        // public virtual async Task<IEnumerable<ExtraToppingsOnItemView>> GetAllForViewAsync(int minLocationsCount = 10,
        //     double minDuration = 60, double minDistance = 10, DateTime? fromDateTime = null,
        //     DateTime? toDateTime = null)
        // {
        //     var query = RepoDbSet
        //         .Include(a => a.ExtraToppingsOnItemType)
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
        //         .Select(a => new ExtraToppingsOnItemView()
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
        //             ExtraToppingsOnItemType = a.ExtraToppingsOnItemType!.Name,
        //             UserFirstLastName = a.AppUser!.FirstName + " " + a.AppUser!.LastName,
        //             UserId = a.AppUserId,
        //         }).ToListAsync();
        //
        //     return result;
        // }
        //
        // public async Task<ExtraToppingsOnItem> GetFirstWithAllLocationsAsync(Guid id)
        // {
        //     var domainExtraToppingsOnItem = await RepoDbSet.AsNoTracking()
        //         .FirstOrDefaultAsync(a => a.Id == id);
        //
        //     domainExtraToppingsOnItem.GpsLocations = await RepoDbContext.GpsLocations.AsNoTracking()
        //         .Where(l => l.ExtraToppingsOnItemId == id)
        //         .OrderByDescending(l => l.RecordedAt)
        //         .ToListAsync();
        //
        //     return Mapper.Map(domainExtraToppingsOnItem);
        // }
        public Task<IEnumerable<ExtraToppingsOnItem>> GetAllAsync(Guid balanceId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<ExtraToppingsOnItem> GetFirstWithAllLocationsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
