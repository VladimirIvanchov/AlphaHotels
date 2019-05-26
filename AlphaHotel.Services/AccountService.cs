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
using AlphaHotel.ViewModels;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;

namespace AlphaHotel.Services
{
    public class AccountService : IAccountService
    {
        private readonly AlphaHotelDbContext context;
        private readonly UserManager<User> userManager;
        private readonly IMappingProvider mapper;

        public AccountService(AlphaHotelDbContext context, UserManager<User> userManager, IMappingProvider mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IReadOnlyCollection<AccountViewModel>> ListAllUsersAsync()
        {
            return await userManager.Users
                  .Include(u => u.UsersLogbooks)
                      .ThenInclude(ul => ul.LogBook)
                  .Include(u => u.Business)
                  .ProjectTo<AccountViewModel>()
                  .ToListAsync();


            //userManager.GetRolesAsync()

            //return await this.context.Users
            //    .Include(u => u.UsersLogbooks)
            //        .ThenInclude(ur => ur.LogBook)
            //    .ToListAsync();
        }

        //public async Task<User> FindUserAsync(string username)
        //{
        //    var user = await this.userManager
        //        .FindByNameAsync(username);

        //    await this.userManager.GetRolesAsync(user);

        //    if (user == null)
        //    {

        //    }

        //}
    }
}
