using Banking.Clients.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Infra.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(c => c.Passport)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder
                .Property(c => c.Birthday)                
                .IsRequired();

            builder
                .HasOne(c => c.Address)
                .WithOne(a => a.Client)
                .HasForeignKey<Address>(a => a.ClientId);

            builder.ToTable("Clients");
        }
    }
}
