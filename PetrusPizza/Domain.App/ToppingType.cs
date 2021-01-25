using System;
using System.Collections.Generic;
using ee.itcollege.mrajam.Domain.Base;

namespace Domain.App
{
    public class ToppingType: DomainEntityIdMetadata
    {
        public Guid NameId { get; set; }
        public LangStr? Name { get; set; }
        
        public Guid DescriptionId { get; set; }
        public LangStr? Description { get; set; }
        
        public ICollection<ExtraToppingsOnItem>? ExtraToppingsOnItems { get; set; }
        public ICollection<DefaultTopping>? DefaultToppings { get; set; }
    }
}