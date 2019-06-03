using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaHotel.Data.Configurations
{
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.Property(a => a.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(a => a.Icon)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
