using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class DefaultToppingsDTO : IDomainEntityId
    {
        public Guid Id { get; set; }
        public string PizzaName { get; set; } = default!;
        public string ToppingName { get; set; } = default!;
        public virtual DateTime CreatedAt { get; set; } = default!;
        public virtual string CreatedBy { get; set; } = default!;
    }
    

}