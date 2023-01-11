using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Module4HW3.DataModel.Configuration
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProject").HasKey(e => e.EmployeeProjectId);
            builder.Property(e => e.EmployeeProjectId).HasColumnName("EmployeeProjectId").ValueGeneratedOnAdd();
            builder.Property(e => e.StartedDate).IsRequired().HasColumnName("StartedDate");
            builder.Property(e => e.Rate).IsRequired().HasColumnName("Rate");
            builder.HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Project)
               .WithMany(e => e.EmployeeProjects)
               .HasForeignKey(p => p.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
