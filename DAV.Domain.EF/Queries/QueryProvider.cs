using System.Linq;
using DAV.Domain.EF.Context;
using DAV.Domain.Queries.Providers;
using Microsoft.EntityFrameworkCore;

namespace DAV.Domain.EF.Queries
{
    public class QueryProvider<T> : IQueryProvider<T> where T : class 
    {
        private readonly ApplicationContext _context;
        public QueryProvider(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        IQueryable<T> IQueryProvider<T>.Query => _context.Set<T>().AsNoTracking();
    }
}
