using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using OrderRow = ee.itcollege.mrajam.BLL.App.DTO.OrderRow;

namespace PublicApi.DTO.v1
{
    public class ItemRowDTO : IDomainEntityId
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public ICollection<OrderRow> OrderRows { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
    }
}