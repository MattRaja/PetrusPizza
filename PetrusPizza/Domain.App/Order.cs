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
    
    public class Order: DomainEntityIdMetadataUser<AppUser>
    {
        // [ForeignKey(nameof(AppUserOrder))]
        // [MaxLength(36)]
        // public virtual Guid AppUserOrderId { get; set; } = default!;
        // public virtual AppUser AppUserOrder { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(SumWithoutVAT), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal SumWithoutVAT { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(SumWithVAT), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal SumWithVAT { get; set; } = default!;
        [Display(Name = nameof(OrderNr), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual string OrderNr { get; set; } = default!;
        [Display(Name = nameof(OrderDate), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual DateTime OrderDate { get; set; } = default!;
        
        [InverseProperty(nameof(OrderRow.Order))]
        public virtual ICollection<OrderRow> OrderRows { get; set; } = default!;
        public virtual Guid AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }
    }
}