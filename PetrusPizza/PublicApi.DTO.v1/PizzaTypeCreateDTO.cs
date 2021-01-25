using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class PizzaTypeCreateDTO
    {
        public Guid Id { get; set; }
        public string PizzaTypeName { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; } = default!;
        
    }
}