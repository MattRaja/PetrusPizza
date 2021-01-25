using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.DAL.Base;
using ee.itcollege.mrajam.Domain.Base;
using Domain.App.Identity;
using ee.itcollege.mrajam.Domain.Base;
using ee.itcollege.mrajam;

namespace Domain.App
{
    
    public class ExtraToppingsOnItem: DomainEntityIdMetadataUser<AppUser>
    {
        [ForeignKey(nameof(ToppingName))]
        [MaxLength(36)]
        public virtual Guid ToppingNameId { get; set; }
        public virtual Topping? ToppingName { get; set; }
        
        [ForeignKey(nameof(ItemRow))]
        [MaxLength(36)]
        public virtual Guid ItemRowId { get; set; } = default!;
        public virtual ItemRow ItemRow { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Price { get; set; } = default!;

        // [InverseProperty(nameof(OrderRow.ExtraToppingsOnItemName))]
        // public ICollection<OrderRow> OrderRows { get; set; } = default!;
        // public virtual TKey AppUserId{ get; set; }  = default!;
        // public virtual TUser? AppUser { get; set; }


    }
}