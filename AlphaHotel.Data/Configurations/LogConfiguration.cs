using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaHotel.Data.Configurations
{
    internal class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.Property(a => a.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(a => a.AuthorId)
               .IsRequired();
        }
    }
}
