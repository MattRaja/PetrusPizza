using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Newtonsoft.Json;

namespace PublicApi.DTO.v1
{
    public class PizzaNameJsonDTO
    {
        [JsonProperty("NameOfPizza")]
        public string NameOfPizza { get; set; } = default!;
        [JsonProperty("Price")]
        [Column(TypeName = "decimal(7,2)")]
        public string Price { get; set; } = default!;
        [JsonProperty("DefaultToppingsOut")]
        public List<string> DefaultToppingsOut { get; set; } = default!;
        [JsonProperty("AppUserId")]
        public string AppUserId { get; set; } = default!;
    }
}