using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Newtonsoft.Json;

namespace PublicApi.DTO.v1
{
    public class PizzaNameDTO : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        public string NameOfPizza { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]

        public string Price { get; set; } = default!;

        public List<string> DefaultToppings { get; set; } = default!;
        public Guid AppUserId { get; set; }
    }
}