using AlphaHotel.DTOs;
using AlphaHotel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface ILogBookService
    {
        Task<ICollection<LogDTO>> ListAllLogsForManagerAsync(string id);
    }
}
