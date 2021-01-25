using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.mrajam.Contracts.Domain;
using Domain.App;
using OrderRow = ee.itcollege.mrajam.BLL.App.DTO.OrderRow;

namespace PublicApi.DTO.v1
{
    public class OrderDTO : IDomainEntityId
    {
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(7,2)")]
        public decimal SumWithoutVAT { get; set; } = default!;
        [Column(TypeName = "decimal(7,2)")]
        public decimal SumWithVAT { get; set; } = default!;
        public string OrderNr { get; set; } = default!;
        public DateTime OrderDate { get; set; } = default!;
        public ICollection<OrderRow> OrderRows { get; set; } = default!;
        public string AppUserId { get; set; } = default!;
    }
}