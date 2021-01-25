using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using Newtonsoft.Json;

namespace PublicApi.DTO.v1
{
    public class OrderRowCreateDTO
    {
        [JsonProperty("Price")]
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; } = default!;
        [JsonProperty("ExtraToppingsOnItems")]
        public string[] ExtraToppingsOnItems { get; set; } = default!;
        [JsonProperty("NameOfPizza")]
        public string NameOfPizza { get; set; } = default!;
        [JsonProperty("PizzaSize")]
        public string PizzaSize { get; set; } = default!;
        [JsonProperty("PizzaType")]
        public string PizzaType { get; set; } = default!;
        [JsonProperty("AppUserId")]
        public string AppUserId { get; set; } = default!;
    }
}