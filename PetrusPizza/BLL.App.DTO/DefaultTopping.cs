using System;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    
    public class DefaultTopping: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;

        public virtual string ToppingId { get; set; } = default!;

        //public virtual Topping ToppingName { get; set; } = default!;
        
        public virtual string PizzaNameId { get; set; } = default!;
        //public virtual PizzaName PizzaName { get; set; } = default!;
        public virtual string Price { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }

    }
    
}