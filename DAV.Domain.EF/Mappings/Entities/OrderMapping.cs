using DAV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAV.Domain.EF.Mappings
{
    public class OrderMapping : EntityMapping<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();

            builder.Property(i => i.SupplierId).IsRequired();
            builder.Property(i => i.DateTime).IsRequired();
            builder.Property(i => i.StatusId).IsRequired();
            builder.Property(i => i.IsActive);
        }
    }
}
