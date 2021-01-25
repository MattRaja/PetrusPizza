using System;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    
    public class DefaultTopping : IDomainEntityId
    

    {
        public Guid Id { get; set; } = default!;

        public virtual string PizzaNameId { get; set; } = default!;
        //public virtual PizzaName? PizzaName { get; set; } = default!;
        
        public virtual string ToppingId { get; set; } = default!;
        //public virtual Topping ToppingName { get; set; } = default!;
        
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }


    }

}