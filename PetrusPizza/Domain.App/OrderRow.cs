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
    public class OrderRow: DomainEntityIdMetadataUser<AppUser>
    {
        [ForeignKey(nameof(Order))]
        [MaxLength(36)]
        public virtual Guid? OrderId { get; set; }
        public virtual Order? Order { get; set; }
        
        [ForeignKey(nameof(ItemRow))]
        [MaxLength(36)]
        public virtual Guid? ItemRowId { get; set; }
        public virtual ItemRow? ItemRow { get; set; }

        // [ForeignKey(nameof(ExtraToppingsOnItemName))]
        // [MaxLength(36)]
        // public virtual Guid ExtraToppingsOnItemNameId { get; set; } = default!;
        // public virtual ExtraToppingsOnItem? ExtraToppingsOnItemName { get; set; }
        // [Display(Name = nameof(Amount), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        // public virtual int Amount { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Price { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(VAT), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal VAT { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Sum), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Sum { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(SumWithVAT), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal SumWithVAT { get; set; } = default!;
        public virtual Guid AppUserId { get; set; } = default!;
        public virtual string PizzaSize { get; set; } = default!;
        public virtual string PizzaType { get; set; } = default!;
        public virtual string NameOfPizza { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }

    }
}