using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ee.itcollege.mrajam.BLL.App.DTO.Identity;
using ee.itcollege.mrajam.Contracts.Domain;

namespace ee.itcollege.mrajam.BLL.App.DTO
{
    public class PaymentMethod: IDomainEntityId

    {
        public Guid Id { get; set; } = default!;
        public virtual string PaymentMethodName { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
        [JsonIgnore]
        public AppUser? AppUser { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }

    }
}