using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Infrastructure.Wrappers.Contracts;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using AlphaHotel.Services.Utilities;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services
{
    public class LogBookService : ILogBookService
    {
        private readonly AlphaHotelDbContext context;
        private readonly IMappingProvider mapper;
        private readonly IPaginatedList<LogDTO> paginatedList;
        private readonly IDateTimeWrapper dateTime;
        private readonly IUserManagerWrapper<User> userManager;

        public LogBookService(AlphaHotelDbContext context, IMappingProvider mapper, IPaginatedList<LogDTO> paginatedList, IDateTimeWrapper dateTime, IUserManagerWrapper<User> userManager)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.paginatedList = paginatedList ?? throw new ArgumentNullException(nameof(paginatedList));
            this.dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<IPaginatedList<LogDTO>> ListAllLogsForManagerAsync(string id, int? pageNumber, int pageSize, string keyword)
        {
            //return await this.context.UsersLogbooks
            //    .Include(ul => ul.LogBook)
            //        .ThenInclude(lb => lb.Logs)
            //            .ThenInclude(l => l.Author)
            //    .Include(ul => ul.LogBook)
            //        .ThenInclude(lb => lb.Logs)
            //            .ThenInclude(l => l.Status)
            //    .Include(ul => ul.LogBook)
            //        .ThenInclude(lb => lb.Logs)
            //            .ThenInclude(l => l.Category)
            //    .Where(ul => ul.UserId == id)
            //    .SelectMany(ul => ul.LogBook.Logs)
            //    .ToListAsync();
            //.ProjectTo<LogDTO>()

            //var logs = this.context.LogBooks
            //    //.Include(l => l.LogBook.ManagersLogbooks)
            //.Where(l => l.ManagersLogbooks.)
            //keyword = keyword ?? "";
            var logbooksIds = await this.context.UsersLogbooks
                .Where(ul => ul.UserId == id)
                .Select(ul => ul.LogBook.Id)
                .ToListAsync();

            var logsQuery = this.context.Logs
                .Include(l => l.Status)
                .Include(l => l.Category)
                .Include(l => l.Status)
                .Where(l => logbooksIds.Contains(l.LogBookId))
                .Where(l => l.Description.ToLower().Contains(keyword) || l.Category.Name.ToLower().Contains(keyword) || l.CreatedOn.Date.ToString("dd MMM yyyy").ToLower().Contains(keyword))
                .OrderByDescending(l => l.CreatedOn)
                .ProjectTo<LogDTO>();

            return await this.paginatedList.CreateAsync(logsQuery, pageNumber ?? 1, pageSize, keyword);
        }

        //public async Task<ICollection<LogDTO>> FindLogAsync(string keyword, string managerId, int? pageNumber, int pageSize)
        //{
        //    if (keyword != null)
        //    {
        //        pageNumber = 1;
        //    }
        //    else
        //    {
        //        keyword = this.paginatedList.CurrentFilter;
        //    }

        //    var logbooksIds = await this.context.UsersLogbooks
        //        .Where(ul => ul.UserId == managerId)
        //        .Select(ul => ul.LogBook.Id)
        //        .ToListAsync();

        //    var logsQuery = this.context.Logs
        //       .Include(l => l.Status)
        //       .Include(l => l.Category)
        //       .Include(l => l.Status)
        //       .Where(l => logbooksIds.Contains(l.LogBookId))
        //       .Where(l => l.Description.ToLower().Contains(keyword) || l.Category.Name.ToLower().Contains(keyword) || l.CreatedOn.Date.ToString("dd MMM yyyy").ToLower().Contains(keyword))
        //       .OrderByDescending(l => l.CreatedOn)
        //       .ProjectTo<LogDTO>();


        //    return await this.paginatedList.CreateAsync(logsQuery, pageNumber ?? 1, pageSize, keyword);
        //}

        public async Task<ICollection<StatusDTO>> ListAllStatusesAsync()
        {
            return await this.context.Statuses
                .ProjectTo<StatusDTO>()
                .ToListAsync();
        }

        public async Task<int> ChangeStatusOfLogAsync(int statusId, int logId)
        {
            var log = await this.context.Logs
                .Include(l => l.Status)
                .Where(l => l.Id == logId)
                .FirstOrDefaultAsync();

            if (log == null)
            {
                throw new ArgumentException($"Log with id: {logId} do not exist!");
            }

            var statusesCount = await this.context.Statuses.CountAsync();

            if (statusId < 0 || statusId > statusesCount)
            {
                throw new ArgumentException($"Status: {statusId} do not exist!");
            }

            log.StatusId = statusId;
            return await this.context.SaveChangesAsync();
        }

        public async Task AddLog(int logbookId, string userId, string description, int categoryId)
        {
            var logbook = await this.context.LogBooks.FindAsync(logbookId);
            var author = await this.context.Users.FindAsync(userId);
            var category = await this.context.Categories.FindAsync(categoryId);

            if (logbook == null)
                throw new ArgumentException($"LogBook with id {logbookId} doesn't exist!");

            if (author == null)
                throw new ArgumentException($"User with id {userId} doesn't exist!");

            if (category == null)
                throw new ArgumentException($"Category with id {categoryId} doesn't exist!");

            var log = new Log()
            {
                LogBookId = logbookId,
                AuthorId = userId,
                CategoryId = categoryId,
                IsDeleted = false,
                CreatedOn = dateTime.Now(),
                StatusId = 1
            };

            if (!string.IsNullOrEmpty(description))
            {
                log.Description = description;
            }

            this.context.Logs.Add(log);
            await this.context.SaveChangesAsync();
        }

        public async Task<LogBooksCategoriesDTO> GetLogBooksAndCategories(string userId)
        {
            var user = await this.context.Users.FindAsync(userId);
            var role = "Manager";

            if (user == null)
                throw new ArgumentException($"User with id {userId} doesn't exist");

            var roleCheck = await this.userManager.IsInRoleAsync(user, role);

            if (!roleCheck)
            {
                throw new ArgumentException($"Manager with id {userId} doesn't exist");
            }

            var logbooks = await this.context.UsersLogbooks
                .Where(x => x.UserId == userId)
                .Select(ul => ul.LogBook)
                .ProjectTo<LogBookDTO>()
                .ToListAsync();

            var categories = await this.context.Categories
               .ProjectTo<CategoryDTO>()
               .ToListAsync();

            var logbooksAndCategories = new LogBooksCategoriesDTO()
            {
                LogBooks = logbooks,
                Categories = categories
            };

            return logbooksAndCategories;
        }
    }
}
