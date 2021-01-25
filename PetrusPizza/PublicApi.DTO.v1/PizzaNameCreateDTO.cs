using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using Domain.App;
using Topping = ee.itcollege.mrajam.BLL.App.DTO.Topping;

namespace PublicApi.DTO.v1
{
    public class PizzaNameCreateDTO
    {
        public Guid Id { get; set; }
        
        public string NameOfPizza { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]

        public decimal Price { get; set; } = default!;
        
        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        
        public List<Topping> ToppingList { get; set; } = new List<Topping>();
        public List<string> DefaultToppings { get; set; } = default!;
        
    }
}