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
    public class FacilityTestUtils
    {
        public static DbContextOptions<AlphaHotelDbContext> GetOptions(string DbName)
        {
            return new DbContextOptionsBuilder<AlphaHotelDbContext>()
                .UseInMemoryDatabase(DbName)
                .Options;
        }

        public static void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
                cfg.AddProfile<MappingProfile>();
            });
        }

        public static void ResetAutoMapper()
        {
            Mapper.Reset();
        }

        public static void GetContextWithFacilities(string DbName, int facilityId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var facility = new Facility()
            {
                Id = facilityId
            };
            context.Facilities.Add(facility);
            context.SaveChanges();
        }
    }
}
