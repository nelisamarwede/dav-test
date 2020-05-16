using DAV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAV.Domain.EF.Mappings.Entities
{
    public class ProductLineMapping : EntityMapping<ProductLine>
    {
        public override void Configure(EntityTypeBuilder<ProductLine> builder)
        {
            builder.ToTable("ProductLines");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.Qty).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.UnitPrice).IsRequired();
            builder.Property(i => i.OrderId).IsRequired();
            builder.Property(i => i.IsActive);
        }
    }
}
