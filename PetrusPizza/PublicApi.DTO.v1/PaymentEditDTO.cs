using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using Domain.App.Identity;

namespace PublicApi.DTO.v1
{
    public class PaymentEditDTO
    {
        public Guid Id { get; set; }
        
        public PaymentMethod PaymentMethodName { get; set; } = default!;
        
        public AppUser UserPayment { get; set; } = default!;
        
        public Order OrderPayment { get; set; } = default!;

        public DateTime PaymentDate { get; set; } = default!;

        public decimal PaymentAmount { get; set; } = default!;
    }
}