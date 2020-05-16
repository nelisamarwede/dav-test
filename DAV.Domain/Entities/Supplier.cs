using DAV.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.Entities
{
    public class Supplier : IEntity, IEntityLookup
    {
        public int? Id { get; set; }

        public string SupplierName { get; set; }

        public bool? IsActive { get; set; } = true;
        public object LookupId => Id;

        public object LookupValue => SupplierName;
    }
}
