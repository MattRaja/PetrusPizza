using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;

namespace PublicApi.DTO.v1.Identity
{
    public class AppUser : IDomainEntityId
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        
        [MinLength(1)]
        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; } = default!;

        [MinLength(1)]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; } = default!;

        public string FirstLastName => FirstName + " " + LastName;
        public string LastFirstName => LastName + " " + FirstName;
    }
}