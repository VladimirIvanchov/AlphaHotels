using AlphaHotel.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IAccountService
    {
        Task<IReadOnlyCollection<AccountViewModel>> ListAllUsersAsync();
    }
}
