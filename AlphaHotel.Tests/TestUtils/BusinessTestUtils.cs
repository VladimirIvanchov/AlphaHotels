using System;
using System.Collections.Generic;
using System.Text;
using AlphaHotel.Common;
using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.TestUtils
{
    public class BusinessTestUtils
    {
        public static DbContextOptions<AlphaHotelDbContext> GetOptions(string DbName)
        {
            return new DbContextOptionsBuilder<AlphaHotelDbContext>()
                .UseInMemoryDatabase(DbName)
                .Options;
        }

        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<MappingProfiles>();
                cfg.AddProfile<MappingProfile>();
            });
        }

        public static void ResetAutoMapper()
        {
            Mapper.Reset();
        }

        //ListTopNBusinessAsync_Should, FindDetailedBusinessAsync_Should
        public static void GetContextWithBusinessAndFeedback(string DbName, int businessId, int feedbackRating)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);

            var feedback = new Feedback()
            {
                BusinessId = businessId,
                Rate = feedbackRating
            };

            var business = new Business()
            {
                Id = businessId,
            };
            context.Businesses.Add(business);
            context.Feedbacks.Add(feedback);
            context.SaveChanges();
        }

        //AddLogBookToBusinessAsync_Should, ListBusinessLogbooksAsync_ReturnLogBooks
        public static void GetContextWithBusinessAndLogBook(string DbName, int businessId, string logbookName)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);

            var logbook = new LogBook()
            {
                BusinessId = businessId,
                Name = logbookName
            };

            var business = new Business()
            {
                Id = businessId,
            };
            context.Businesses.Add(business);
            context.LogBooks.Add(logbook);
            context.SaveChanges();
        }

        //CreateBusiness_Should
        public static void GetContextWithBusiness(string DbName, int businessId, string businessName)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);

            var business = new Business()
            {
                Id = businessId,
                Name = businessName
            };
            context.Businesses.Add(business);
            context.SaveChanges();
        }

        //CreateBusiness_Should
        public static void GetContextWithFullBusiness(string DbName, string businessName, string location, string about, string shortDescription, string coverPic)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);

            var business = new Business()
            {
                Name = businessName,
                Location = location,
                About = about,
                ShortDescription = shortDescription,
                CoverPicture = coverPic
            };
            context.Businesses.Add(business);
            context.SaveChanges();
        }
    }
}
