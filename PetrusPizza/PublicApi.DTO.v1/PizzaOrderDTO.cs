using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using PizzaName = ee.itcollege.mrajam.BLL.App.DTO.PizzaName;

namespace PublicApi.DTO.v1
{
    public class PizzaOrderDTO : IDomainEntityId
    {
        public Guid Id { get; set; }

        public PizzaName PizzaName { get; set; } = default!;
        
        public PizzaSize PizzaSize { get; set; } = default!;
        
        public PizzaType PizzaType { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; } = default!;
        
        public ICollection<ItemRow> ItemRows { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
    }
}