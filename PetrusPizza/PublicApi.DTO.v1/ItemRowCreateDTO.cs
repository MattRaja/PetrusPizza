using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class ItemRowCreateDTO
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; } = default!;
        
    }
}