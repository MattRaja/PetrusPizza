using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class OrderRowEditDTO
    {
        public Guid Id { get; set; }

        public int Amount { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal VAT { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal Sum { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal SumWithVAT { get; set; } = default!;
    }
}