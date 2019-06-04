using AlphaHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IFacilityService
    {
        Task<ICollection<FacilityDTO>> ListAllFacilitiesAsync();
    }
}
