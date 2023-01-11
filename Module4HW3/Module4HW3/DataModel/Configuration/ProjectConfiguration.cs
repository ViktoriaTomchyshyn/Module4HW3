using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW3.DataModel.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project").HasKey(p => p.ProjectId);
            builder.Property(p => p.ProjectId).HasColumnName("ProjectId").ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasColumnName("Name").HasMaxLength(255);
            builder.Property(p => p.Budjet).IsRequired().HasColumnName("Budjet");
            builder.Property(p => p.StartedDate).IsRequired().HasColumnName("StartedDate");
            builder.Property(p => p.ClientId).IsRequired().HasColumnName("ClientId");
            builder.HasOne(o => o.Client)
                     .WithMany(e => e.Projects)
                     .HasForeignKey(o => o.ClientId)
                     .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(new List<Project>()
            {
                new Project()
                {
                    ProjectId = 1, Name = "MedicalSystem", Budjet = 100000, StartedDate = System.DateTime.Now, ClientId = 1
                },
                new Project()
                {
                    ProjectId = 2, Name = "CosmeticsShop", Budjet = 500000, StartedDate = System.DateTime.Now, ClientId = 2
                },
                new Project()
                {
                    ProjectId = 3, Name = "HomeShop", Budjet = 1000000, StartedDate = System.DateTime.Now, ClientId = 2
                },
                new Project()
                {
                    ProjectId = 4, Name = "SchoolDiary", Budjet = 200000, StartedDate = System.DateTime.Now, ClientId = 3
                },
                new Project()
                {
                    ProjectId = 5, Name = "HealthMentainer", Budjet = 6000000, StartedDate = System.DateTime.Now, ClientId = 4
                },
                new Project()
                {
                    ProjectId = 6, Name = "GreenShop", Budjet = 500000, StartedDate = System.DateTime.Now, ClientId = 5
                }
            });
        }
    }
}
