using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class PizzaOrderEditDTO
    {
        public Guid Id { get; set; }

        public PizzaName PizzaName { get; set; } = default!;
        
        public PizzaSize PizzaSize { get; set; } = default!;
        
        public PizzaType PizzaType { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; } = default!;
        
        public ICollection<ItemRow> ItemRows { get; set; } = default!;
    }
}