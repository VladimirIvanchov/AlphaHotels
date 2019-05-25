using AlphaHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IBusinessService
    {
        Task<ICollection<BusinessViewModel>> ListAllBusinesses();
        Task<ICollection<LogBookViewModel>> ListBusinessLogbooks(int id);
    }
}
