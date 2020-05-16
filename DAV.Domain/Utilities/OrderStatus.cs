using System;
using System.Collections.Generic;
using System.Text;

namespace DAV.Domain.Utilities
{
    public enum OrderStatus
    {
        New = 1,
        InTransit = 2,
        Cancelled = 3,
        Received = 4
    }
}
