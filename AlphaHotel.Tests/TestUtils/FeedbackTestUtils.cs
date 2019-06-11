using System;
using System.Collections.Generic;
using System.Text;
using AlphaHotel.Common;
using AlphaHotel.Data;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Models;
using AlphaHotel.Tests.Services.FeedbackServiceTests;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.TestUtils
{
    public class FeedbackTestUtils
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

        //FindFeedback_Should
        public static void GetContextWithFeedbackId(string DbName, int id)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var feedback = new Feedback()
            {
                Id = id
            };
            context.Feedbacks.Add(feedback);
            context.SaveChanges();
        }

        //AddFeedbackAsync_Should, EditFeedback_Should
        public static void GetContextWithFullFeedback(string DbName, string feedbackText, int rating, string author, int businessId, int feedbackId, bool isDeleted = false)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var business = new Business()
            {
                Id = businessId
            };

            var feedback = new Feedback()
            {
                Id = feedbackId,
                BusinessId = businessId,
                Author = author,
                Rate = rating,
                Text = feedbackText,
                IsDeleted = isDeleted
            };

            context.Feedbacks.Add(feedback);
            context.Businesses.Add(business);
            context.SaveChanges();
        }

        //AddFeedbackAsync_Should
        public static void GetContextWithFullFeedbackAndAnonymousAuthor(string DbName, string feedbackText, int rating, string author, int businessId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var business = new Business()
            {
                Id = businessId
            };

            var feedback = new Feedback()
            {
                BusinessId = businessId,
                Author = "Anonymous",
                Rate = rating,
                Text = feedbackText,
                IsDeleted = false
            };

            context.Feedbacks.Add(feedback);
            context.Businesses.Add(business);
            context.SaveChanges();
        }
        
        //ListAllFeedbacksForModeratorAsync_Should
        public static void GetContextWithFeedbackIdAndBusinessAndModerator(string DbName, int feedbackId, string moderatorId, int businessId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var feedback = new Feedback()
            {
                Id = feedbackId,
                BusinessId = businessId
            };

            var moderator = new User()
            {
                Id = moderatorId,
                BusinessId = businessId
            };

            var business = new Business()
            {
                Id = businessId
            };

            context.Feedbacks.Add(feedback);
            context.Users.Add(moderator);
            context.Businesses.Add(business);
            context.SaveChanges();
        }

        //ListAllFeedbacksForUserAsync_Should
        public static void GetContextWithFeedbackIdAndBusiness(string DbName, int feedbackId, int businessId, bool isDeleted = false)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var feedback = new Feedback()
            {
                Id = feedbackId,
                BusinessId = businessId,
                IsDeleted = isDeleted
            };

            var business = new Business()
            {
                Id = businessId
            };

            context.Feedbacks.Add(feedback);
            context.Businesses.Add(business);
            context.SaveChanges();
        }

    }
}
