using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaHotel.Data.Configurations
{
    public class BusinessesFacilitiesConfiguration : IEntityTypeConfiguration<BusinessesFacilities>
    {
        public void Configure(EntityTypeBuilder<BusinessesFacilities> builder)
        {
            builder
                 .HasKey(bf => new { bf.BusinessId, bf.FacilityId });

            builder
                .HasOne(bf => bf.Business)
                .WithMany(b => b.BusinessesFacilities)
                .HasForeignKey(bf => bf.BusinessId);

            builder
                .HasOne(bf => bf.Facility)
                .WithMany(f => f.BusinessesFacilities)
                .HasForeignKey(bf => bf.FacilityId);
        }
    }
}
