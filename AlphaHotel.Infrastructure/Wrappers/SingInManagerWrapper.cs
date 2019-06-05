using AlphaHotel.Infrastructure.Wrappers.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AlphaHotel.Infrastructure.Wrappers
{
    public class SingInManagerWrapper<T> : ISingInManagerWrapper<T>
        where T : IdentityUser
    {
        private readonly SignInManager<T> signInManager;

        public SingInManagerWrapper(SignInManager<T> signInManager)
        {
            this.signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await this.signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public async Task SignInAsync(T user, bool isPersistent)
        {
            await this.signInManager.SignInAsync(user, isPersistent);
        }

        public async Task SignOutAsync()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
