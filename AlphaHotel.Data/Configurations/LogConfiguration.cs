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

            builder.Property(a => a.StatusId)
               .HasDefaultValue(1);

            builder.Property(a => a.CategoryId)
               .HasDefaultValue(1);
        }
    }
}
