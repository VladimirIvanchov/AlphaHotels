﻿using AlphaHotel.Common;
using AlphaHotel.Data;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        //FindLog_Should
        public static void GetContextWithLog(string DbName, int logId, string description)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var log = new Log()
            {
                Id = logId,
                Description = description
            };
            context.Logs.Add(log);
            context.SaveChanges();
        }

        //GetLogBooksAndCategories_Should
        public static void GetContextWithUserAndLogBookAndCategory(string DbName, string userId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var usersLogBooks = new List<UsersLogbooks>() { new UsersLogbooks { UserId = userId, LogBookId = 1 } };
            var category = new Category()
            {
                Id = 1
            };
            var logbook = new LogBook()
            {
                Id = 1,
                ManagersLogbooks = usersLogBooks
            };
            var user = new User()
            {
                Id = userId
            };
            context.Users.Add(user);
            context.Categories.Add(category);
            context.LogBooks.Add(logbook);
            context.SaveChanges();
        }

        //GetLogBooksAndCategories_Should
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

        //AddLog_Should
        public static void GetContextWithFullLogAndLogBookAndUserAndStatusAndCategory(string DbName, int logbookId, string userId, int categoryId, string description, string username, int statusId, string statusType, string categoryName, bool isDeleted = false)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var category = new Category()
            {
                Id = categoryId,
                Name = categoryName
            };
            var status = new Status()
            {
                Id = statusId,
                Type = statusType
            };
            var user = new User()
            {
                Id = userId,
                UserName = username
            };
            //var log = new Log
            //{
            //    LogBookId = logbookId,
            //    AuthorId = userId,
            //    CategoryId = categoryId,
            //    Description = description,
            //    IsDeleted = isDeleted,
            //    StatusId = statusId
            //};
            var logbook = new LogBook()
            {
                Id = logbookId
            };
            //context.Logs.Add(log);
            context.Users.Add(user);
            context.Statuses.Add(status);
            context.Categories.Add(category);
            context.LogBooks.Add(logbook);
            context.SaveChanges();
        }

        //ChangeStatusOfLogAsync_Should
        public static void GetContextWithLogAndStatuses(string DbName, int logId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);

            var status = new Status()
            {
                Id = 1
            };
            var status2 = new Status()
            {
                Id = 2
            };
            var log = new Log
            {
                Id = logId,
                StatusId = status.Id
            };
            context.Logs.Add(log);
            context.Statuses.Add(status);
            context.Statuses.Add(status2);
            context.SaveChanges();
        }

        //ChangeStatusOfLogAsync_Should
        public static void GetContextWithLogAndStatuses(string DbName, int logId, int statusId, int statusId2)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);

            var status = new Status()
            {
                Id = statusId
            };
            var status2 = new Status()
            {
                Id = statusId2
            };
            var log = new Log
            {
                Id = logId,
                StatusId = status.Id
            };
            context.Logs.Add(log);
            context.Statuses.Add(status);
            context.Statuses.Add(status2);
            context.SaveChanges();
        }

        //AddLog_Should
        public static void GetContextWithLogBook(string DbName, int logbookId)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var logbook = new LogBook()
            {
                Id = logbookId
            };
            context.LogBooks.Add(logbook);
            context.SaveChanges();
        }

        //FindLog_Should
        public static void GetContextWithLogAndAuthorAndStatusAndCategory(string DbName, int logId, string description)
        {
            var options = GetOptions(DbName);

            var context = new AlphaHotelDbContext(options);
            var user = new User()
            {
                Id = "user"
            };
            var status = new Status()
            {
                Id = 1
            };
            var category = new Category()
            {
                Id = 1
            };
            var log = new Log()
            {
                Id = logId,
                Description = description,
                Author = user,
                Category = category,
                Status = status
            };
            context.Logs.Add(log);
            context.Users.Add(user);
            context.Statuses.Add(status);
            context.Categories.Add(category);
            context.SaveChanges();
        }

    }
}
