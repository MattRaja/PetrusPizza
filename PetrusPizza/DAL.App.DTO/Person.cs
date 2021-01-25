using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;
using DAL.App.DTO.Identity;

namespace DAL.App.DTO
{
    
    public class Person: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual string FirstName { get; set; } = default!;
        public virtual string LastName { get; set; } = default!;
        
        public AppUser? AppUser { get; set; }
        public Guid AppUserId { get; set; }


        public virtual ICollection<Balance> Balances { get; set; } = default!;

    }
}