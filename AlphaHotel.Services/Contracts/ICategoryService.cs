using AlphaHotel.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDTO>> ListAllCategoriesAsync();
        Task<int> AddCategory(string categoryName);
    }
}
