using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;

namespace PublicApi.DTO.v1
{
    public class BalanceDTO : IDomainEntityId
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }  = default!;
        public Guid PaymentId { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;

    }
    

}