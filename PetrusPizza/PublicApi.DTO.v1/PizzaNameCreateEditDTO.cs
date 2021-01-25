using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using Domain.App;
using Newtonsoft.Json;
using AppUser = ee.itcollege.mrajam.BLL.App.DTO.Identity.AppUser;
using Topping = ee.itcollege.mrajam.BLL.App.DTO.Topping;

namespace PublicApi.DTO.v1
{
    public class PizzaNameCreateEditDTO
    {
        public Guid Id { get; set; }
        [JsonProperty("NameOfPizza")]

        public string NameOfPizza { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [JsonProperty("Price")]
        public decimal Price { get; set; } = default!;
        
        public Guid AppUserId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public AppUser? AppUser { get; set; }
        
        public bool Clicked { get; set; }
        public virtual DateTime CreatedAt { get; set; } = default!;
        public virtual string CreatedBy { get; set; } = default!;
        
        public List<Topping> ToppingList { get; set; } = new List<Topping>();
        public List<string> DefaultToppingsIn { get; set; } = default!;
        [JsonProperty("DefaultToppingsOut")]
        public List<string> DefaultToppingsOut { get; set; } = default!;
        public List<string> DefaultToppings { get; set; } = default!;
        
    }
}