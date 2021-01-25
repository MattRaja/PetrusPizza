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
    public class PizzaOrder: DomainEntityIdMetadataUser<AppUser>
    {
        
        [ForeignKey(nameof(PizzaName))]
        [MaxLength(36)]
        public virtual Guid PizzaId { get; set; } = default!;
        public virtual PizzaName PizzaName { get; set; } = default!;
        
        [ForeignKey(nameof(PizzaSize))]
        [MaxLength(36)]
        public virtual Guid PizzaSizeId { get; set; } = default!;
        public virtual PizzaSize PizzaSize { get; set; } = default!;
        
        [ForeignKey(nameof(PizzaType))]
        [MaxLength(36)]
        public virtual Guid PizzaTypeId { get; set; } = default!;
        public virtual PizzaType PizzaType { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Price { get; set; } = default!;

        [InverseProperty(nameof(ItemRow.PizzaOrder))]
        public virtual ICollection<ItemRow> ItemRows { get; set; } = default!;
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }

    }
}