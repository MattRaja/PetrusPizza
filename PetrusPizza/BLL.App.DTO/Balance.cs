using System;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    
    public class Balance: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;

        public virtual Guid PersonId { get; set; } = default!;
        public virtual Person? Person { get; set; }
        
        public virtual Guid PaymentId { get; set; } = default!;
        public virtual Payment? Payment { get; set; }

        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual AppUser AppUser { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }

    }
    
}