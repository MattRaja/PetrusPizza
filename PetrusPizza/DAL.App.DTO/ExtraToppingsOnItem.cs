using System;
using System.Collections.Generic;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class ExtraToppingsOnItem: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual Guid ToppingNameId { get; set; } = default!;
        public virtual Topping ToppingName { get; set; } = default!;
        
        public virtual Guid ItemRowId { get; set; } = default!;
        public virtual ItemRow ItemRow { get; set; } = default!;
        public virtual decimal Price { get; set; } = default!;
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public ICollection<OrderRow> OrderRows { get; set; } = default!;

    }
}