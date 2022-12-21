using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestSolution.Domain.Models;

namespace TestSolution.Infrastructure.Database.Communication.Mapping.EF
{
    public class RegisterMappingEF : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.ToTable("Register", "Test");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.address)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(c => c.age).IsRequired();
            builder.Property(c => c.birth_date).IsRequired();
            builder.Property(c => c.first_name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(c => c.gender)
                .HasMaxLength(1)
                .IsRequired();
            builder.Property(c => c.last_name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(c => c.phone)
                .HasMaxLength(20);
        }
    }
}
