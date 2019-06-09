using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AlphaHotel.Infrastructure.Wrappers.Contracts
{
    public interface IUserManagerWrapper<T> where T : class
    {
        Task<T> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        IQueryable<T> Users { get; }
        Task<IdentityResult> AddToRoleAsync(T user, string role);
        string GetUserId(ClaimsPrincipal principal);
        Task<IdentityResult> CreateAsync(T user, string password);
        Task<IList<string>> GetRolesAsync(T user);
        Task<bool> IsInRoleAsync(T user, string role);
        Task<T> FindByNameAsync(string userName);
        Task<IdentityResult> SetEmailAsync(T user, string email);
        Task<IdentityResult> ChangePasswordAsync(T user, string currentPassword, string newPassword);
    }
}
