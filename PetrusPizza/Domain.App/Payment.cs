using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.DAL.Base;
using ee.itcollege.mrajam.Domain.Base;
using Domain.App.Identity;

namespace Domain.App
{
    public class Payment: DomainEntityIdMetadataUser<AppUser>
    {
        
        // [ForeignKey(nameof(PaymentMethodName))]
        // [MaxLength(36)]
        // public virtual Guid PaymentMethodNameId { get; set; } = default!;
        // public virtual PaymentMethod PaymentMethodName { get; set; } = default!;
        
        // [ForeignKey(nameof(AppUserPayment))]
        // [MaxLength(36)]
        // public virtual Guid AppUserPaymentId { get; set; } = default!;
        // public virtual AppUser AppUserPayment { get; set; } = default!;

        [ForeignKey(nameof(OrderPayment))]
        [MaxLength(36)]
        public virtual Guid OrderPaymentId { get; set; } = default!;
        public virtual Order OrderPayment { get; set; } = default!;
        [Display(Name = nameof(PaymentDate), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]

        public virtual DateTime PaymentDate { get; set; } = default!;

        // [Column(TypeName = "decimal(7,2)")]
        // [Display(Name = nameof(PaymentAmount), ResourceType = typeof(Resources.Domain.CommonCalculation))]
        // public virtual decimal PaymentAmount { get; set; } = default!;

        [InverseProperty(nameof(Balance.Payment))]
        public virtual ICollection<Balance> Balances { get; set; } = default!;
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }

    }
}