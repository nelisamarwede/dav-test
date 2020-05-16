using Microsoft.EntityFrameworkCore;

namespace DAV.Domain.EF.Mappings
{
    public interface IMappingConfig
    {
        void Register(ModelBuilder modelBuilder);
    }
}
