using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Module4HW3.DataModel.Configuration
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Office").HasKey(p => p.OfficeId);
            builder.Property(p => p.OfficeId).HasColumnName("OfficeId").ValueGeneratedOnAdd();
            builder.Property(p => p.Title).IsRequired().HasColumnName("Title").HasMaxLength(255);
            builder.Property(p => p.Location).IsRequired().HasColumnName("Location").HasMaxLength(255);
        }
    }
}
