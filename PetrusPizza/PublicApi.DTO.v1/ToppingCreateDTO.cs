using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class ToppingCreateDTO
    {
        public Guid Id { get; set; }

        public string ToppingName { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public string Price { get; set; } = default!;
        
        public  ICollection<ExtraToppingsOnItem>? ExtraToppingsOnItems { get; set; }
    }
}