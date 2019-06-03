using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AlphaHotel.Models;
using AlphaHotel.Data.Configurations;
using System.IO;
using Newtonsoft.Json;

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
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<BusinessesFacilities> BusinessesFacilities { get; set; }
        public DbSet<Facility> Facilities { get; set; }

        private void LoadJson(ModelBuilder modelBuilder)
        {
            //System.Diagnostics.Debugger.Launch();
            var businessesPath = @"..\AlphaHotel.Data\JsonFiles\businesses.json";
            var categoriesPath = @"..\AlphaHotel.Data\JsonFiles\categories.json";
            var feedbacksPath = @"..\AlphaHotel.Data\JsonFiles\feedbacks.json";
            var logBooksPath = @"..\AlphaHotel.Data\JsonFiles\logBooks.json";
            var logsPath = @"..\AlphaHotel.Data\JsonFiles\logs.json";
            var statusPath = @"..\AlphaHotel.Data\JsonFiles\status.json";
            var picturesPath = @"..\AlphaHotel.Data\JsonFiles\pictures.json";
            var facilitiesPath = @"..\AlphaHotel.Data\JsonFiles\facilities.json";
            var businessesfacilitiesPath = @"..\AlphaHotel.Data\JsonFiles\businessesfacilities.json";

            //var isPathFound = File.Exists(businessesPath) && File.Exists(categoriesPath) &&
            //File.Exists(feedbacksPath) && File.Exists(logBooksPath) && File.Exists(logsPath) &&
            //File.Exists(statusPath);

            //if (isPathFound)
            try
            {
                var businessesJson = File.ReadAllText(businessesPath);
                var categoriesJson = File.ReadAllText(categoriesPath);
                var feedbacksJson = File.ReadAllText(feedbacksPath);
                var logBooksJson = File.ReadAllText(logBooksPath);
                var logsJson = File.ReadAllText(logsPath);
                var statusJson = File.ReadAllText(statusPath);
                var pictureJson = File.ReadAllText(picturesPath);
                var facilityJson = File.ReadAllText(facilitiesPath);
                var businessesfacilitiesJson = File.ReadAllText(businessesfacilitiesPath);

                var businesses = JsonConvert.DeserializeObject<Business[]>(businessesJson);
                var categories = JsonConvert.DeserializeObject<Category[]>(categoriesJson);
                var feedbacks = JsonConvert.DeserializeObject<Feedback[]>(feedbacksJson);
                var logBooks = JsonConvert.DeserializeObject<LogBook[]>(logBooksJson);
                var logs = JsonConvert.DeserializeObject<Log[]>(logsJson);
                var status = JsonConvert.DeserializeObject<Status[]>(statusJson);
                var pictures = JsonConvert.DeserializeObject<Picture[]>(pictureJson);
                var facilities = JsonConvert.DeserializeObject<Facility[]>(facilityJson);
                var businessesfacilities = JsonConvert.DeserializeObject<BusinessesFacilities[]>(businessesfacilitiesJson);

                modelBuilder.Entity<Business>().HasData(businesses);
                modelBuilder.Entity<Category>().HasData(categories);
                modelBuilder.Entity<Feedback>().HasData(feedbacks);
                modelBuilder.Entity<LogBook>().HasData(logBooks);
                modelBuilder.Entity<Log>().HasData(logs);
                modelBuilder.Entity<Status>().HasData(status);
                modelBuilder.Entity<Picture>().HasData(pictures);
                modelBuilder.Entity<Facility>().HasData(facilities);
                modelBuilder.Entity<BusinessesFacilities>().HasData(businessesfacilities);
            }
            catch (Exception)
            {
                return;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            LoadJson(builder);

            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new FeedbackConfiguration());
            builder.ApplyConfiguration(new LogBookConfiguration());
            builder.ApplyConfiguration(new LogConfiguration());
            builder.ApplyConfiguration(new StatusConfiguration());
            builder.ApplyConfiguration(new UsersLogbooksConfiguration());
            builder.ApplyConfiguration(new BusinessConfiguration());
            builder.ApplyConfiguration(new PictureConfiguration());
            builder.ApplyConfiguration(new FacilityConfiguration());
            builder.ApplyConfiguration(new BusinessesFacilitiesConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
