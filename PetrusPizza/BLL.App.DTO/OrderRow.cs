using System;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
   
    public class OrderRow: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual Guid? OrderId { get; set; }
        // public virtual Order? Order { get; set; }
        
        public virtual Guid? ItemRowId { get; set; }
        // public virtual ItemRow? ItemRow { get; set; }
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        //public AppUser? AppUser { get; set; }
        //public virtual Guid ExtraToppingsOnItemNameId { get; set; } = default!;
        //public virtual ExtraToppingsOnItem? ExtraToppingsOnItemName { get; set; }
        //public virtual int Amount { get; set; } = default!;
        public virtual string NameOfPizza { get; set; } = default!;
        public virtual decimal Price { get; set; } = default!;
        public virtual decimal VAT { get; set; } = default!;
        public virtual decimal Sum { get; set; } = default!;
        public virtual decimal SumWithVAT { get; set; } = default!;
        public virtual string PizzaType { get; set; } = default!;
        public virtual string PizzaSize { get; set; } = default!;

        

    }
}