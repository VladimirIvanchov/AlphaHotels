using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Services.Contracts;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly AlphaHotelDbContext context;

        public FacilityService(AlphaHotelDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<FacilityDTO>> ListAllFacilitiesAsync()
        {
            return await this.context.Facilities
                .ProjectTo<FacilityDTO>()
                .ToListAsync();
        }
    }
}
