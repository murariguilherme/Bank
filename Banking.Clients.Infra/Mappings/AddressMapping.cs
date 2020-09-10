using Banking.Clients.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banking.Clients.Infra.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .Property(a => a.StreetAddress)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(a => a.City)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(a => a.State)
                .HasColumnType("varchar(255)")
                .IsRequired();

            builder
                .Property(a => a.PostalCode)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.ToTable("Addresses");
        }
    }
}
