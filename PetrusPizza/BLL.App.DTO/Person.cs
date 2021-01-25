using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    
    public class Person: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual string FirstName { get; set; } = default!;
        public virtual string LastName { get; set; } = default!;

        public virtual Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public virtual AppUser? AppUser { get; set; }

        public virtual ICollection<Balance> Balances { get; set; } = default!;

    }
}