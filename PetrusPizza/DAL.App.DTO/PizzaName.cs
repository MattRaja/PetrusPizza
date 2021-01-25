using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class PizzaName : IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        
        public virtual string NameOfPizza { get; set; } = default!;
        public virtual string Price { get; set; } = default!;
        public Guid AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public virtual DateTime CreatedAt { get; set; } = default!;
        public virtual string CreatedBy { get; set; } = default!;

        //public virtual ICollection<PizzaOrder>? PizzaOrders { get; set; }
        public virtual ICollection<DefaultTopping>? DefaultToppings { get; set; }

    }
}