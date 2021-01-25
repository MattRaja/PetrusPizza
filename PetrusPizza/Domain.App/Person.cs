using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.DAL.Base;
using ee.itcollege.mrajam.Domain.Base;
using Domain.App.Identity;

namespace Domain.App
{
    public class Person: DomainEntityIdMetadataUser<AppUser>
    {
        [MaxLength(128)]
        [MinLength(1)]
        [Display(Name = nameof(FirstName), ResourceType = typeof(Resources.Domain.Identity.AppUser))]
        public virtual string FirstName { get; set; } = default!;
        [MaxLength(128)]
        [MinLength(1)]
        [Display(Name = nameof(LastName), ResourceType = typeof(Resources.Domain.Identity.AppUser))]
        public virtual string LastName { get; set; } = default!;

        // public virtual TKey AppUserId { get; set; } = default!;
        // public virtual TUser? AppUser { get; set; }

        [InverseProperty(nameof(Balance.Person))]
        public virtual ICollection<Balance> Balances { get; set; } = default!;

    }
}