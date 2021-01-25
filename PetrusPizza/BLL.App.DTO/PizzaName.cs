using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    // public class PizzaName : PizzaName<Guid>, IDomainEntityId
    // {
    //     
    // }
    public class PizzaName : IDomainEntityId

    {
        public Guid Id { get; set; } = default!;

        [Display(Name = nameof(NameOfPizza),
            ResourceType = typeof(Resources.Domain.Names.Names))]
        [MinLength(1, ErrorMessageResourceName = "ErrorMessage_MinLength",
            ErrorMessageResourceType = typeof(Resources.Common))]
        [MaxLength(256, ErrorMessageResourceName = "ErrorMessage_MaxLength",
            ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required",
            ErrorMessageResourceType = typeof(Resources.Common))]

        public virtual string NameOfPizza { get; set; } = default!;

        [Display(Name = nameof(Price),
            ResourceType = typeof(Resources.Domain.Common.CommonCalculation))]
        //[MinLength(1, ErrorMessageResourceName = "ErrorMessage_MinLength",
        //ErrorMessageResourceType = typeof(Resources.Common))]
        //[MaxLength(256, ErrorMessageResourceName = "ErrorMessage_MaxLength",
        //ErrorMessageResourceType = typeof(Resources.Common))]
        [Required(ErrorMessageResourceName = "ErrorMessage_Required",
            ErrorMessageResourceType = typeof(Resources.Common))]
        public virtual string Price { get; set; } = null!;

        // [MinLength(1, ErrorMessageResourceName = "ErrorMessage_MinLength", ErrorMessageResourceType = typeof(Resources.Common))]
        // [MaxLength(256, ErrorMessageResourceName = "ErrorMessage_MaxLength", ErrorMessageResourceType = typeof(Resources.Common))]
        // [Required(ErrorMessageResourceName = "ErrorMessage_Required", ErrorMessageResourceType = typeof(Resources.Common))]
        //[JsonIgnore]
        //public virtual ICollection<PizzaOrder>? PizzaOrders { get; set; }
        public virtual List<string> DefaultToppings { get; set; } = default!;
        public virtual DateTime CreatedAt { get; set; } = default!;
        public virtual string CreatedBy { get; set; } = default!;

        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        

    }
}