using System;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace DAL.App.DTO
{
    public class Balance: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;

        public virtual Guid PersonId { get; set; } = default!;
        public virtual Person Person { get; set; } = default!;
        
        public virtual Guid PaymentId { get; set; } = default!;
        public virtual Payment Payment { get; set; } = default!;
        
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual AppUser AppUser { get; set; } = default!;
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

    }
    
    public class BalanceDisplay
    {
        public Guid Id { get; set; } = default!;
        public virtual Guid PersonId { get; set; } = default!;
        public virtual Person Person { get; set; } = default!;
        
        public virtual Guid PaymentId { get; set; } = default!;
        public virtual Payment Payment { get; set; } = default!;

    }

}