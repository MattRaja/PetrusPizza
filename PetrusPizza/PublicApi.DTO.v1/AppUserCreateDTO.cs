using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class AppUserCreateDTO
    {
        public Guid Id { get; set; }

        [MinLength(1)][MaxLength(64)]public string FirstName { get; set; } = default!;
        [MinLength(1)][MaxLength(64)]public string LastName { get; set; } = default!;
        //[Column(TypeName = "decimal(7,2)")]public decimal MoneyInWallet { get; set; } = default!;
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Balance>? Balances { get; set; }
    }
}