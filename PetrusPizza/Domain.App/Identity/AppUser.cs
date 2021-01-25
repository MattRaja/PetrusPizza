using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppUser : IdentityUser<Guid>, IDomainEntityId
    {
        [MaxLength(64)]
        [MinLength(1)]
        //[Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.App.Identity.AppUser))]
        [Required]
        public virtual string FirstName { get; set; } = default!;

        [MaxLength(64)]
        [MinLength(1)]
        //[Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.App.Identity.AppUser))]
        [Required]

        public virtual string LastName { get; set; } = default!;
        // [Column(TypeName = "decimal(7,2)")]
        // [Display(Name = nameof(MoneyInWallet), ResourceType = typeof(Resources.Domain.App.Identity.AppUser))]
        // public decimal MoneyInWallet { get; set; } = default!;

        [InverseProperty(nameof(Payment.AppUser))]
        public ICollection<Payment>? Payments { get; set; }
        
        // [InverseProperty(nameof(Order.AppUserOrder))]
        // public ICollection<Order>? Orders { get; set; }
        //
        [InverseProperty(nameof(Balance.AppUser))]
        public ICollection<Balance>? Balances { get; set; }

        // public virtual string CreatedBy { get; set; } = default!;
        // public virtual DateTime CreatedAt { get; set; } = default!;
        // public virtual string ChangedBy { get; set; } = default!;
        // public virtual DateTime ChangedAt { get; set; } = default!;
    }
}