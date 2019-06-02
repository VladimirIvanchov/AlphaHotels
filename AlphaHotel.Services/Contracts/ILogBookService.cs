using AlphaHotel.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface ILogBookService
    {
        Task<ICollection<LogDTO>> ListAllLogsForManagerAsync(string id);
        Task<ICollection<StatusDTO>> ListAllStatusesAsync();
        Task<int> ChangeStatusOfLogAsync(int statusId, int logId);
        Task<ICollection<LogDTO>> FindLogAsync(string keyword, string managerId);
    }
}
