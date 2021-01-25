using System;
using System.Collections.Generic;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    public class Order: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual Guid? AppUserOrderId { get; set; } = default!;
        public virtual AppUser? AppUserOrder { get; set; } = default!;
        public virtual decimal SumWithoutVAT { get; set; } = default!;
        public virtual decimal SumWithVAT { get; set; } = default!;
        public virtual string OrderNr { get; set; } = default!;
        public virtual DateTime OrderDate { get; set; } = default!;
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; } = default!;

    }
}