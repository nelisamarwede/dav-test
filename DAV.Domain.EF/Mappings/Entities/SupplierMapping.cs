
using DAV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAV.Domain.EF.Mappings.Entities
{
    public class SupplierMapping : EntityMapping<Supplier>
    {
        public override void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.SupplierName).IsRequired();

        }
    }
}
