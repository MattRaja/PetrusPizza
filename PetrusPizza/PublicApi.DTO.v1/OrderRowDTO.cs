using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using ee.itcollege.mrajam.Contracts.Domain;

namespace PublicApi.DTO.v1
{
    public class OrderRowDTO : IDomainEntityId
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SumWithVAT { get; set; } = default!;
        public string NameOfPizza { get; set; } = default!;
        public string PizzaType { get; set; } = default!;
        public string PizzaSize { get; set; } = default!;
        public decimal? Price { get; set; }
        public decimal? Sum { get; set; }
        

        public Guid AppUserId { get; set; } = default!;
    }
}