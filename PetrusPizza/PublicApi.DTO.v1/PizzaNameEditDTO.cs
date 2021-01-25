using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.App;
using DefaultTopping = ee.itcollege.mrajam.BLL.App.DTO.DefaultTopping;

namespace PublicApi.DTO.v1
{
    public class PizzaNameEditDTO
    {
        public Guid Id { get; set; }
        
        public string NameOfPizza { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]

        public string Price { get; set; } = default!;

        public Guid AppUserId { get; set; } = default!;
        public List<ee.itcollege.mrajam.BLL.App.DTO.Topping> ToppingList { get; set; } = new List<ee.itcollege.mrajam.BLL.App.DTO.Topping>();
        public List<string> DefaultToppingsIn { get; set; } = default!;
        public List<string> DefaultToppingsOut { get; set; } = default!;


        //public int OrderCount { get; set; }
    }
}