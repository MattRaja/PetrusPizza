using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class PersonDTO : IDomainEntityId
    {
        public Guid Id { get; set; }

        [MinLength(1)][MaxLength(64)]public string FirstName { get; set; } = default!;
        [MinLength(1)][MaxLength(64)]public string LastName { get; set; } = default!;
        
        //public Balance[] Balances { get; set; }
        //public string[] Orders { get; set; }
    }
}