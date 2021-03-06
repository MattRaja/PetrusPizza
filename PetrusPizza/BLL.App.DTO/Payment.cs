using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class Payment: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        // public virtual Guid PaymentMethodNameId { get; set; } = default!;
        // public virtual PaymentMethod PaymentMethodName { get; set; } = default!;
        
        // public virtual TKey AppUserPaymentId { get; set; } = default!;
        // public virtual AppUser AppUserPayment { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }

        public virtual Guid OrderPaymentId { get; set; } = default!;
        public virtual Order OrderPayment { get; set; } = default!;

        public virtual DateTime PaymentDate { get; set; } = default!;

        public virtual decimal PaymentAmount { get; set; } = default!;

        public virtual ICollection<Balance> Balances { get; set; } = default!;

        
    }
}