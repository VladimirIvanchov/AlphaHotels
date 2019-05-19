using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlphaHotel.Models;
using AlphaHotel.Data.Configurations;

namespace AlphaHotel.Data
{
    public class AlphaHotelDbContext : IdentityDbContext<User>
    {
        public AlphaHotelDbContext(DbContextOptions<AlphaHotelDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UsersLogbooks> UsersLogbooks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new FeedbackConfiguration());
            builder.ApplyConfiguration(new LogBookConfiguration());
            builder.ApplyConfiguration(new LogConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new UsersLogbooksConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
