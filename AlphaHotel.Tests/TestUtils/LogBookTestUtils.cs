using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AlphaHotel.Data;
using AlphaHotel.Models;
using AutoMapper;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Common;

namespace AlphaHotel.Tests.TestUtils
{
    public class LogBookTestUtils
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
    }
}
