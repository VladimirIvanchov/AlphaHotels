using AlphaHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IBusinessService
    {
        Task<ICollection<BusinessDTO>> ListAllBusinessesAsync();
        Task<ICollection<LogBookDTO>> ListBusinessLogbooksAsync(int id);
        Task<int> AddLogBookToBusinessAsync(string logBookName, int businessId);
    }
}
