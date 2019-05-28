using AlphaHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IBusinessService
    {
        Task<ICollection<T>> ListAllBusinessesAsync<T>();
        Task<ICollection<LogBookDTO>> ListBusinessLogbooksAsync(int id);
        Task<int> AddLogBookToBusinessAsync(string logBookName, int businessId);
        Task<BusinessDetailsDTO> FindDetaliedBusinessAsync(int businessId);
        Task<ICollection<BusinessShortInfoDTO>> ListTopNBusinessesAsync(int counts);
    }
}
