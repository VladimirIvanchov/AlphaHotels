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

        public static void GetContextWithFeedback(string DbName, int id)
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
    }
}
