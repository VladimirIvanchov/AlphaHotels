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

        //ListAllCategoriesAsync_Should
        public static void GetContextWithCategories(string DbName, int categoryId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var category = new Category()
            {
                Id = categoryId
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }

        //AddCategory_Should
        public static void GetContextWithCategory(string DbName, string categoryName)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var category = new Category()
            {
                Name = categoryName
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }
}
