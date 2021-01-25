using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class PizzaOrder: IDomainEntityId

    {
        
        public Guid Id { get; set; } = default!;
        public virtual Guid PizzaId { get; set; } = default!;
        public virtual PizzaName PizzaName { get; set; } = default!;
        
        public virtual Guid PizzaSizeId { get; set; } = default!;
        public virtual PizzaSize PizzaSize { get; set; } = default!;
        
        public virtual Guid PizzaTypeId { get; set; } = default!;
        public virtual PizzaType PizzaType { get; set; } = default!;
        public virtual decimal Price { get; set; } = default!;

        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        public virtual ICollection<ItemRow> ItemRows { get; set; } = default!;

    }
}