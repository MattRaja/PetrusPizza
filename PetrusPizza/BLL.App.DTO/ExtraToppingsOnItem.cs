using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class ExtraToppingsOnItem : IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual Guid ToppingNameId { get; set; } = default!;
        public virtual string ToppingName { get; set; } = default!;
        
        public virtual Guid ItemRowId { get; set; } = default!;
        public virtual ItemRow ItemRow { get; set; } = default!;
        public virtual decimal Price { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; } = default!;

    }
}