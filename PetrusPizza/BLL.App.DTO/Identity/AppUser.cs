using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO.Identity
{
    public class AppUser : IDomainEntityId
    {
        public Guid Id { get; set; }
        [MinLength(1)]
        [MaxLength(128)]
        [Required]

        public virtual string FirstName { get; set; } = default!;
        [MinLength(1)]
        [MaxLength(128)]
        [Required]

        public virtual string LastName { get; set; } = default!;
        //public decimal MoneyInWallet { get; set; } = default!;
/*

        [InverseProperty(nameof(Payment.AppUserPayment))]
        public ICollection<Payment>? Payments { get; set; }
        
        [InverseProperty(nameof(Order.AppUserOrder))]
        public ICollection<Order>? Orders { get; set; }
        
        [InverseProperty(nameof(Balance.AppUser))]
        public ICollection<Balance>? Balances { get; set; }*/

    }
}