using AlphaHotel.Data;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.Wrappers;
using AlphaHotel.Infrastructure.Wrappers.Contracts;

namespace AlphaHotel.Services
{
    public class AccountService : IAccountService
    {
        private readonly AlphaHotelDbContext context;
        private readonly IUserManagerWrapper<User> userManager;
        private readonly IMappingProvider mapper;
        private readonly IDateTimeWrapper dateTime;

        public AccountService(AlphaHotelDbContext context, IUserManagerWrapper<User> userManager, IMappingProvider mapper, IDateTimeWrapper dateTime)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
        }

        public async Task<IReadOnlyCollection<AccountDTO>> ListAllUsersAsync()
        {
            return await userManager.Users
                  .Include(u => u.UsersLogbooks)
                      .ThenInclude(ul => ul.LogBook)
                  .Include(u => u.Business)
                  .ProjectTo<AccountDTO>()
                  .ToListAsync();
        }

        public async Task<AccountDetailsDTO> FindAccountAsync(string accountId)
        {
            var user = await this.userManager.Users
                  .Include(u => u.UsersLogbooks)
                        .ThenInclude(ul => ul.LogBook)
                  .Include(u => u.Business)
                  .Where(u => u.Id == accountId)
                  .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException("Account do not exist!");
            }

            var role = await this.userManager.GetRolesAsync(user);

            var account = this.mapper.MapTo<AccountDetailsDTO>(user);
            account.Role = role.FirstOrDefault();

            return account;
        }

        public async Task<int> EditAccountAsync(string id, string username, string email, bool isDeleted, ICollection<int> logBooks)
        {
            var user = await this.userManager.Users
                  .Include(u => u.UsersLogbooks)
                        .ThenInclude(ul => ul.LogBook)
                  .Where(u => u.Id == id)
                  .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentException($"Account {username} do not exist!");
            }

            if (user.UserName != username)
            {
                var newUserNameIsInUse = await this.context.Users.FirstOrDefaultAsync(u => u.UserName == username);
                if (newUserNameIsInUse != null)
                {
                    throw new ArgumentException($"Username {username} is in use!");
                }
            }

            user.UserName = username;
            user.Email = email;
            if (!user.IsDeleted && isDeleted)
            {
                user.DeletedOn = this.dateTime.Now();
            }

            user.IsDeleted = isDeleted;
            user.ModifiedOn = this.dateTime.Now();
            user.UsersLogbooks.Clear();
            user.UsersLogbooks = logBooks?
                .Select(l => new UsersLogbooks() { LogBookId = l })
                .ToList();

            return await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<string>> CheckIfUserIsAllowedToSeeLogAsync(IReadOnlyDictionary<string, string> userNames, int logbookId)
        {
            return await this.context.UsersLogbooks
                .Where(ul => userNames.Keys.Contains(ul.User.UserName))
                .Where(ul => ul.LogBook.Id == logbookId)
                .Select(ul => ul.User.UserName)
                .ToListAsync();
        }
    }
}
