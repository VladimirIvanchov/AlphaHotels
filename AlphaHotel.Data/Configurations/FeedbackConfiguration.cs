using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaHotel.Data.Configurations
{
    internal class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(a => a.Author)
                .HasMaxLength(20);

            builder.Property(a => a.Text)
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
