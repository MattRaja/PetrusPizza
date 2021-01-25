using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class PizzaSize: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual string PizzaSizeName { get; set; } = default!;
        public virtual string Price { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        
        public virtual ICollection<PizzaOrder>? PizzaOrders { get; set; }

    }
}