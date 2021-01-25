using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
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

        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }


        public virtual ICollection<ItemRow> ItemRows { get; set; } = default!;

    }
}