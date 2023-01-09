using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4HW3.DataModel.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client").HasKey(e => e.ClientId);
            builder.Property(e => e.ClientId).HasColumnName("ClientId").ValueGeneratedOnAdd();
            builder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(255);
            builder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(255);
            builder.Property(e => e.PhoneNumber).IsRequired().HasColumnName("PhoneNumber").HasMaxLength(13);
            builder.Property(e => e.Email).IsRequired().HasColumnName("Email").HasMaxLength(100);
            builder.HasData(new List<Client>()
            {
                new Client()
                {
                    ClientId = 1, FirstName = "Viktoriia", LastName = "Tomchyshyn", Email = "vktrtmchshn@gmail.com", PhoneNumber = "+380978945678"
                },
                new Client()
                {
                    ClientId = 2, FirstName = "Volodymyr", LastName = "Tomchyshyn", Email = "vtmchshn@gmail.com", PhoneNumber = "+380978945600"
                },
                new Client()
                {
                    ClientId = 3, FirstName = "Anastasiia", LastName = "Tomchyshyn", Email = "anasttmchshn@gmail.com", PhoneNumber = "+380958445600"
                },
                new Client()
                {
                    ClientId = 4, FirstName = "Ihor", LastName = "Antoniuk", Email = "ihor.ant@gmail.com", PhoneNumber = "+380937890567"
                },
                new Client()
                {
                    ClientId = 5, FirstName = "Yulia", LastName = "Koval", Email = "yuliakoval@gmail.com", PhoneNumber = "+380937890533"
                }
            });
        }
    }
}