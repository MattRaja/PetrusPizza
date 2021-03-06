using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Newtonsoft.Json;

namespace PublicApi.DTO.v1
{
    public class ToppingJsonDTO
    {
        [JsonProperty("ToppingName")]
        public string ToppingName { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        [JsonProperty("Price")]
        public string Price { get; set; } = default!;
        [JsonProperty("AppUserId")]
        public Guid AppUserId { get; set; } = default!;
    }
}