using AlphaHotel.Data;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services
{
    public class AccountService : IAccountService
    {
        private readonly AlphaHotelDbContext context;
        private readonly UserManager<User> userManager;

        public AccountService(AlphaHotelDbContext context, UserManager<User> userManager)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        
    }
}
