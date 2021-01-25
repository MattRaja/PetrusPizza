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
    public class PaymentMethodRepository :
        EFBaseRepository<AppDbContext, AppUser, Domain.App.PaymentMethod, DAL.App.DTO.PaymentMethod>,
        IPaymentMethodRepository
    {
        public PaymentMethodRepository(AppDbContext repoDbContext) : base(repoDbContext,
            new DALMapper<Domain.App.PaymentMethod, DTO.PaymentMethod>())
        {
        }

        // public override async Task<IEnumerable<PaymentMethod>> GetAllAsync(object? userId = null, bool noTracking = true)
        // {
        //     var query = PrepareQuery(userId, noTracking);
        //     query = query
        //         .Include(g => g.AppUser)
        //         .Include(g => g.PaymentMethodType)
        //         .ThenInclude(g => g!.Name)
        //         .ThenInclude(t => t!.Translations)
        //         .OrderByDescending(a => a.RecordedAt);
        //     var domainItems = await query.ToListAsync();
        //     var result = domainItems.Select(e => Mapper.Map(e));
        //     return result;
        // }
        //
        // public virtual async Task<IEnumerable<PaymentMethodView>> GetAllForViewAsync(int minLocationsCount = 10,
        //     double minDuration = 60, double minDistance = 10, DateTime? fromDateTime = null,
        //     DateTime? toDateTime = null)
        // {
        //     var query = RepoDbSet
        //         .Include(a => a.PaymentMethodType)
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
        //         .Select(a => new PaymentMethodView()
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
        //             PaymentMethodType = a.PaymentMethodType!.Name,
        //             UserFirstLastName = a.AppUser!.FirstName + " " + a.AppUser!.LastName,
        //             UserId = a.AppUserId,
        //         }).ToListAsync();
        //
        //     return result;
        // }
        //
        // public async Task<PaymentMethod> GetFirstWithAllLocationsAsync(Guid id)
        // {
        //     var domainPaymentMethod = await RepoDbSet.AsNoTracking()
        //         .FirstOrDefaultAsync(a => a.Id == id);
        //
        //     domainPaymentMethod.GpsLocations = await RepoDbContext.GpsLocations.AsNoTracking()
        //         .Where(l => l.PaymentMethodId == id)
        //         .OrderByDescending(l => l.RecordedAt)
        //         .ToListAsync();
        //
        //     return Mapper.Map(domainPaymentMethod);
        // }
        public Task<IEnumerable<PaymentMethod>> GetAllAsync(Guid balanceId, Guid? userId = null, bool noTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethod> GetFirstWithAllLocationsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
