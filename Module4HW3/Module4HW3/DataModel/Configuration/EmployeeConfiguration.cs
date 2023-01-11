using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Module4HW3.DataModel.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee").HasKey(e => e.EmployeeId);
            builder.Property(e => e.EmployeeId).HasColumnName("EmployeeId").ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(255);
            builder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(255);
            builder.Property(e => e.HiredDate).IsRequired().HasColumnName("HiredDate");
            builder.Property(e => e.DateOfBirth).IsRequired().HasColumnName("DateOfBirth");
            builder.HasOne(o => o.Office)
                .WithMany(e => e.Employees)
                .HasForeignKey(o => o.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.Title)
               .WithMany(e => e.Employees)
               .HasForeignKey(t => t.TitleId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
