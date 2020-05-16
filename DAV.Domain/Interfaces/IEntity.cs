using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.Interfaces
{
    public interface IEntity
    {
        int? Id { get; set; }
        bool? IsActive { get; set; }
    }

    public interface IEntityLookup
    {
        object LookupId { get; }

        object LookupValue { get; }
    }
}
