using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.DAL.Base;
using ee.itcollege.mrajam.Domain.Base;
using Domain.App.Identity;

namespace Domain.App
{
    public class ItemRow: DomainEntityIdMetadataUser<AppUser>
    {
        [Display(Name = nameof(Amount), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual int Amount { get; set; } = default!;
        
        [ForeignKey(nameof(PizzaOrder))]
        [MaxLength(36)]
        public virtual Guid PizzaOrderId { get; set; } = default!;
        public virtual PizzaOrder PizzaOrder { get; set; } = default!;
        
        [InverseProperty(nameof(OrderRow.ItemRow))]
        public virtual ICollection<OrderRow> OrderRows { get; set; } = default!;
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }

    }
}