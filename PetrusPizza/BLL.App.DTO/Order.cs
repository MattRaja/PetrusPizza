using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
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
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        public virtual ICollection<OrderRow> OrderRows { get; set; } = default!;

    }
}