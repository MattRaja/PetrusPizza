using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class Topping: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual string ToppingName { get; set; } = default!;
        public virtual string Price { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        //[JsonIgnore]
        public virtual ICollection<DefaultTopping>? DefaultToppings { get; set; }
        
        public virtual ICollection<ExtraToppingsOnItem>? ExtraToppingsOnItems { get; set; }
    }
}