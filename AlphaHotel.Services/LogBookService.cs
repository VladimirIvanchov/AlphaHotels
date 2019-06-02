using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
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

        public LogBookService(AlphaHotelDbContext context, IMappingProvider mapper, IPaginatedList<LogDTO> paginatedList)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.paginatedList = paginatedList ?? throw new ArgumentNullException(nameof(paginatedList));
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


    }
}
