using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface ILogBookService
    {
        Task<IPaginatedList<LogDTO>> ListAllLogsForManagerAsync(string id, int? pageNumber, int pageSize, string keyword);
        Task<ICollection<StatusDTO>> ListAllStatusesAsync();
        Task<int> ChangeStatusOfLogAsync(int statusId, int logId);
        //Task<ICollection<LogDTO>> FindLogAsync(string keyword, string managerId, int? pageNumber, int pageSize);
    }
}
