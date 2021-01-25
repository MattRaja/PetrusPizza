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
    public class PizzaType: DomainEntityIdMetadataUser<AppUser>
    {
        [MaxLength(128)]
        [MinLength(1)]
        [Display(Name = nameof(PizzaTypeName), ResourceType = typeof(Resources.Domain.Names.Names))]
        public virtual string PizzaTypeName { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Price { get; set; } = default!;

        [InverseProperty(nameof(PizzaOrder.PizzaType))]
        public virtual ICollection<PizzaOrder>? PizzaOrders { get; set; }
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }
        
    }
}