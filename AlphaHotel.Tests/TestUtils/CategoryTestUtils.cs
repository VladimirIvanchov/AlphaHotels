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
    public class CategoryTestUtils
    {
        public static DbContextOptions GetOptions(string DbName)
        {
            return new DbContextOptionsBuilder()
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
