using System;
using System.Collections.Generic;
using System.Text;
using AlphaHotel.Common;
using AlphaHotel.Data;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.TestUtils
{
    public class AccountTestUtils
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

        //ListAllUsersAsync_Should
        public static void GetContextWithUser(string DbName, string userId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var user = new User()
            {
                Id = userId
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
