using DAV.Domain.Interfaces;
using DAV.Domain.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DAV.Domain.Entities
{
    public class Order : IEntity, IEntityLookup
    {
        public int? Id { get; set; }

        public int SupplierId { get; set; }

        public DateTime DateTime { get; set; }

        public OrderStatus StatusId { get; set; }

        public string Status => StatusId.ToString();

        public bool? IsActive { get; set; } = true;

        public object LookupId => Id;

        public object LookupValue => Id;

        public IEnumerable<ProductLine> ProductLines { get; set; } = new List<ProductLine>();
    }
}
