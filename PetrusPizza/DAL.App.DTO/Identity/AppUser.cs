using System;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.Contracts.Domain;

namespace DAL.App.DTO.Identity
{

    public class AppUser: IDomainEntityId
    {
        public Guid Id { get; set; } = default!;
        public virtual string FirstName { get; set; } = default!;
        public virtual string LastName { get; set; } = default!;
        //public decimal MoneyInWallet { get; set; } = default!;
    }
}