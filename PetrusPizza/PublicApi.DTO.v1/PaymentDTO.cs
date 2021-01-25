using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Domain.App.Identity;
using Order = ee.itcollege.mrajam.BLL.App.DTO.Order;

namespace PublicApi.DTO.v1
{
    public class PaymentDTO : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public PaymentMethod PaymentMethodName { get; set; } = default!;
        
        public Order OrderPayment { get; set; } = default!;

        public DateTime PaymentDate { get; set; } = default!;

        public decimal PaymentAmount { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
    }
}