using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaHotel.Data.Configurations
{
    internal class LogBookConfiguration : IEntityTypeConfiguration<LogBook>
    {
        public void Configure(EntityTypeBuilder<LogBook> builder)
        {
            builder.Property(a => a.Name)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
