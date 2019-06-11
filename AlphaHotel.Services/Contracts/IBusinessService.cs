﻿using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IBusinessService
    {
        Task<ICollection<T>> ListAllBusinessesAsync<T>();
        Task<ICollection<BusinessDTO>> ListAllBusinessesContainsKeyWordAsync(string keyword);
        Task<ICollection<LogBookDTO>> ListBusinessLogbooksAsync(int id);
        Task<int> AddLogBookToBusinessAsync(string logBookName, int businessId);
        Task<BusinessDetailsDTO> FindDetaliedBusinessAsync(int businessId, int feedbacksCount);
        Task<ICollection<BusinessShortInfoDTO>> ListTopNBusinessesAsync(int counts);
        Task<BusinessDTO> CreateBusiness(string name, string location, string about, string shortDescription, string coverPicture, ICollection<string> pictures, ICollection<int> businessFacilities);
        Task<IPaginatedList<BusinessShortInfoDTO>> ListAllBusinessesByPageAsync(int? pageNumber, int pageSize);
    }
}
