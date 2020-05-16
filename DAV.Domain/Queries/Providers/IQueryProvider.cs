using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAV.Domain.Queries.Providers
{
    public interface IQueryProvider<T> where T : class
    {
        IQueryable<T> Query { get; }
    }
}
