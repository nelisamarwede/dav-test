using DAV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.Entities
{
    public class ProductLine : IEntity, IEntityLookup
    {
        public int? Id { get; set; }

        public int Qty { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total  => Qty * UnitPrice;

        public int OrderId { get; set; }

        public bool? IsActive { get; set; } = true;
        public object LookupId => Id;
        public object LookupValue => OrderId;
    }    
}
