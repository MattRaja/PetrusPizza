using System;
using System.Collections.Generic;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class ToppingType: IDomainEntityId
    {
        public Guid Id { get; set; }
        public Guid NameId { get; set; }
        public LangStr? Name { get; set; }
        
        public Guid DescriptionId { get; set; }
        public LangStr? Description { get; set; }
        
        public ICollection<ExtraToppingsOnItem>? ExtraToppingsOnItems { get; set; }
        public ICollection<DefaultTopping>? DefaultToppings { get; set; }
    }
}