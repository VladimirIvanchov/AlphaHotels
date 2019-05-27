using AlphaHotel.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IAccountService
    {
        Task<IReadOnlyCollection<AccountDTO>> ListAllUsersAsync();
        Task<AccountDetailsDTO> FindAccountAsync(string accountId);
        Task<int> EditAccountAsync(string id, string username, string email, bool isDeleted, ICollection<int> logBooks);
    }
}
