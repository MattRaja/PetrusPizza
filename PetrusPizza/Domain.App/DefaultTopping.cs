using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.DAL.Base;
using ee.itcollege.mrajam.Domain.Base;
using Domain.App.Identity;

namespace Domain.App
{
    
  
    public class DefaultTopping : DomainEntityIdMetadataUser<AppUser>
    {
     
        //[ForeignKey(nameof(PizzaNameId))]
        public string PizzaNameId { get; set; } = null!;

        //public PizzaName PizzaName { get; set; } = default!;
        
        //[ForeignKey(nameof(ToppingId))]
        public string ToppingId { get; set; } = null!;

        //public Topping ToppingName { get; set; } = default!;

        // [ForeignKey(nameof(AppUser))]
        // [MaxLength(36)]
        // public TKey AppUserId { get; set; } = default!;
        // public TUser? AppUser { get; set; }

    }
}