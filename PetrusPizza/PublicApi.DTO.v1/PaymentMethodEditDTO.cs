using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class PaymentMethodEditDTO
    {
        public Guid Id { get; set; }
        public string PaymentMethodName { get; set; } = default!;
        public ICollection<Payment>? Payments { get; set; }
    }
}