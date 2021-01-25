using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class OrderRowCartDTO : IDomainEntityId
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SumWithVAT { get; set; } = default!;
        public string NameOfPizza { get; set; } = default!;
        public string[] ExtraToppingsOnItems { get; set; } = default!;
        public string PizzaType { get; set; } = default!;
        public string PizzaSize { get; set; } = default!;
        

        public Guid AppUserId { get; set; } = default!;
    }
}