using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.DAL.Base;
using ee.itcollege.mrajam.DAL.Base;
using ee.itcollege.mrajam.Domain.Base;
using Domain.App.Identity;
using ee.itcollege.mrajam.Domain.Base;

namespace Domain.App
{
    
  
    public class Balance : DomainEntityIdMetadataUser<AppUser>
    {
        [ForeignKey(nameof(Person))]
        [MaxLength(36)]
        public Guid PersonId { get; set; }
        public Person? Person { get; set; }
        
        [ForeignKey(nameof(Payment))]
        [MaxLength(36)]
        public virtual Guid PaymentId { get; set; }
        public Payment? Payment { get; set; }
        
        // [ForeignKey(nameof(AppUser))]
        // [MaxLength(36)]
        // public TKey AppUserId { get; set; } = default!;
        // public TUser? AppUser { get; set; }
        
    }
}