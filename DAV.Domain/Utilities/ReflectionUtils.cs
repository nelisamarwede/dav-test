using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAV.Domain.Utilities
{
    public static class ReflectionUtils
    {
        public static IEnumerable<Type> GetTypes<T>()
        {
            var typeToFind = typeof(T);

            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();

            return assembliesToScan.Where(i => i.FullName.StartsWith("Da"))
                .SelectMany(s => s.GetTypes())
                .Where(p => typeToFind.IsAssignableFrom(p) && !p.IsAbstract);
        }
    }
}
