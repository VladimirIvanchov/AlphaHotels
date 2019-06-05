using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AlphaHotel.Infrastructure.Wrappers.Contracts
{
    public interface ISingInManagerWrapper<T> where T : IdentityUser
    {
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);

        Task SignInAsync(T user, bool isPersistent);

        Task SignOutAsync();
    }
}
