using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW3.DataModel.Configuration
{
    public class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder.ToTable("Title").HasKey(p => p.TitleId);
            builder.Property(p => p.TitleId).HasColumnName("TitleId").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
        }
    }
}
