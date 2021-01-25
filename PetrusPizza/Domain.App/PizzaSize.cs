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
    public class PizzaSize: DomainEntityIdMetadataUser<AppUser>
    {
        [MaxLength(128)]
        [MinLength(1)]
        [Display(Name = nameof(PizzaSizeName), ResourceType = typeof(Resources.Domain.Names.Names))]
        public virtual string PizzaSizeName { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Price { get; set; } = default!;
        
        [InverseProperty(nameof(PizzaOrder.PizzaSize))]
        public virtual ICollection<PizzaOrder>? PizzaOrders { get; set; }

        // public TKey AppUserId { get; set; } = default!;
        // public TUser? AppUser { get; set; }
    }
}