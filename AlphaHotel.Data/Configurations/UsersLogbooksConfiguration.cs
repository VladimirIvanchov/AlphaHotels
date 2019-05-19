using AlphaHotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlphaHotel.Data.Configurations
{
    internal class UsersLogbooksConfiguration : IEntityTypeConfiguration<UsersLogbooks>
    {
        public void Configure(EntityTypeBuilder<UsersLogbooks> builder)
        {
            builder
                 .HasKey(ul => new { ul.UserId, ul.LogBookId});

            builder
                .HasOne(ul => ul.User)
                .WithMany(u => u.UsersLogbooks)
                .HasForeignKey(ul => ul.UserId);

            builder
                .HasOne(ul => ul.LogBook)
                .WithMany(l => l.ManagersLogbooks)
                .HasForeignKey(ul => ul.LogBookId);
        }
    }
}
