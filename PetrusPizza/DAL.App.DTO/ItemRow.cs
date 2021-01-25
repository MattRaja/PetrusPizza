using System;
using System.Collections.Generic;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class ItemRow : IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual int Amount { get; set; } = default!;
        
        public virtual Guid PizzaOrderId { get; set; } = default!;
        public virtual PizzaOrder PizzaOrder { get; set; } = default!;
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; } = default!;

    }
}