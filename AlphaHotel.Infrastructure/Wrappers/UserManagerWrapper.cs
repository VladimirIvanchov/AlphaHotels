using AlphaHotel.Infrastructure.Wrappers.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlphaHotel.Infrastructure.Wrappers
{
    public class UserManagerWrapper<T> : IUserManagerWrapper<T> where T : class
    {
        private readonly UserManager<T> userManager;

        public UserManagerWrapper(UserManager<T> userManager)
        {
            this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IQueryable<T> Users => this.userManager.Users;
        public async Task<T> GetUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            return await this.userManager.GetUserAsync(claimsPrincipal);
        }

        public async Task<IdentityResult> AddToRoleAsync(T user, string role)
        {
            return await this.userManager.AddToRoleAsync(user, role);
        }

        public string GetUserId(ClaimsPrincipal principal)
        {
            return this.userManager.GetUserId(principal);
        }

        public async Task<IdentityResult> CreateAsync(T user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task<IList<string>> GetRolesAsync(T user)
        {
            return await this.userManager.GetRolesAsync(user);
        }

        public async Task<T> FindByNameAsync(string userName)
        {
            return await this.userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> SetEmailAsync(T user, string email)
        {
            return await this.userManager.SetEmailAsync(user, email);
        }

        public async Task<IdentityResult> ChangePasswordAsync(T user, string currentPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
    }
}
