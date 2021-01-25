using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class ToppingTypeDTO : IDomainEntityId
    {
        public Guid Id { get; set; }
        public string PizzaName { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
    

}