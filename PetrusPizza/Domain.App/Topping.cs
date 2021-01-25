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
    public class Topping: DomainEntityIdMetadataUser<AppUser>
    {
        [MaxLength(128)]
        [MinLength(1)]
        [Display(Name = nameof(ToppingName), ResourceType = typeof(Resources.Domain.Names.Names))]
        public virtual string ToppingName { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [Display(Name = nameof(Price), ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        public virtual decimal Price { get; set; } = default!;
        
        [InverseProperty(nameof(ExtraToppingsOnItem.ToppingName))]
        public virtual ICollection<ExtraToppingsOnItem>? ExtraToppingsOnItems { get; set; }
        //[InverseProperty(nameof(DefaultTopping.ToppingId))]
        public virtual ICollection<DefaultTopping>? DefaultToppings { get; set; }
        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }
    }
}