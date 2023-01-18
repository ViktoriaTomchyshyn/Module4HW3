using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW3.DataModel.Configuration;

namespace Module4HW3.DataModel
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

            var section = config.GetSection("SqlConnectionString");
            var connection = section.Get<string>();

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
