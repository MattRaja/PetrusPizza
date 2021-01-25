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
    public class PaymentMethod: DomainEntityIdMetadataUser<AppUser>
    {
        // [MaxLength(128)]
        // [MinLength(1)]
        // [Display(Name = nameof(PaymentMethodName), ResourceType = typeof(Resources.Domain.Names))]
        // public virtual string PaymentMethodName { get; set; } = default!;
        //
        // [InverseProperty(nameof(Payment.PaymentMethodName))]
        // public virtual ICollection<Payment>? Payments { get; set; }
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }

    }
}