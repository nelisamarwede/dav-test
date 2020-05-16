using DAV.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAV.Domain.EF.Mappings.Entities
{
    public class StatusMapping : EntityMapping<Status>
    {
        public override void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(i => i.Id);
            builder.Property(i => i.StatusName)
                .HasColumnName("Description")
                .IsRequired();
        }
    }
}
