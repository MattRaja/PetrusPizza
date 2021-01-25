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
    public class ItemRowRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.ItemRow, DAL.App.DTO.ItemRow>,
        IItemRowRepository
    {
        public ItemRowRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.ItemRow, DTO.ItemRow>())
        {
        }

        // public override async Task<IEnumerable<ItemRow>> GetAllAsync(object? userId = null, bool noTracking = true)
        // {
        //     var query = PrepareQuery(userId, noTracking);
        //     query = query
        //         .Include(g => g.AppUser)
        //         .Include(g => g.ItemRowType)
        //         .ThenInclude(g => g!.Name)
        //         .ThenInclude(t => t!.Translations)
        //         .OrderByDescending(a => a.RecordedAt);
        //     var domainItems = await query.ToListAsync();
        //     var result = domainItems.Select(e => Mapper.Map(e));
        //     return result;
        // }
        //
        // public virtual async Task<IEnumerable<ItemRowView>> GetAllForViewAsync(int minLocationsCount = 10,
        //     double minDuration = 60, double minDistance = 10, DateTime? fromDateTime = null,
        //     DateTime? toDateTime = null)
        // {
        //     var query = RepoDbSet
        //         .Include(a => a.ItemRowType)
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
        //         .Select(a => new ItemRowView()
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
        //             ItemRowType = a.ItemRowType!.Name,
        //             UserFirstLastName = a.AppUser!.FirstName + " " + a.AppUser!.LastName,
        //             UserId = a.AppUserId,
        //         }).ToListAsync();
        //
        //     return result;
        // }
        //
        // public async Task<ItemRow> GetFirstWithAllLocationsAsync(Guid id)
        // {
        //     var domainItemRow = await RepoDbSet.AsNoTracking()
        //         .FirstOrDefaultAsync(a => a.Id == id);
        //
        //     domainItemRow.GpsLocations = await RepoDbContext.GpsLocations.AsNoTracking()
        //         .Where(l => l.ItemRowId == id)
        //         .OrderByDescending(l => l.RecordedAt)
        //         .ToListAsync();
        //
        //     return Mapper.Map(domainItemRow);
        // }
        public Task<IEnumerable<ItemRow>> GetAllAsync(Guid balanceId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<ItemRow> GetFirstWithAllLocationsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
