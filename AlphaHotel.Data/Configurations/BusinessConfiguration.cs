using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Data.Configurations
{
    internal class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.Property(a => a.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(a => a.Location)
               .HasMaxLength(60)
               .IsRequired();
        }
    }
}
