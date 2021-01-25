using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using Microsoft.EntityFrameworkCore;
using OrderRow = ee.itcollege.mrajam.BLL.App.DTO.OrderRow;

namespace PublicApi.DTO.v1
{
    public class ExtraToppingsOnItemDTO : IDomainEntityId
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(7,2)")] public decimal Price { get; set; } = default!;

        public string ToppingName { get; set; } = default!;
        public ICollection<OrderRow> OrderRows { get; set; } = default!;
        public Guid AppUserId { get; set; } = default!;
    }
}