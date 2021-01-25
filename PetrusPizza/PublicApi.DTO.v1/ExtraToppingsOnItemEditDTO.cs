using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class ExtraToppingsOnItemEditDTO
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; } = default!;
    }
}