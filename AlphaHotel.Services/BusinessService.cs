using AlphaHotel.Data;
using AlphaHotel.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using AlphaHotel.Models;

namespace AlphaHotel.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly AlphaHotelDbContext context;
        private readonly IMappingProvider mapper;

        public BusinessService(AlphaHotelDbContext context, IMappingProvider mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ICollection<BusinessDTO>> ListAllBusinessesAsync()
        {
            var businesses = await this.context.Businesses
                .ProjectTo<BusinessDTO>()
                .ToListAsync();

            return businesses;
        }

        public async Task<ICollection<LogBookDTO>> ListBusinessLogbooksAsync(int id)
        {
            var businesses = await this.context.LogBooks
                .Where(l => l.BusinessId == id)
                .ProjectTo<LogBookDTO>()
                .ToListAsync();

            return businesses;
        }

        public async Task<int> AddLogBookToBusinessAsync(string logBookName, int businessId)
        {
            var logbook = await this.context.LogBooks.FirstOrDefaultAsync(l => l.Name == logBookName && l.BusinessId == businessId);

            if (logbook != null)
            {
                throw new ArgumentException($"Logbook {logBookName} already exist!");
            }

            var newLogbook = new LogBook
            {
                Name = logBookName,
                BusinessId = businessId
            };

            this.context.LogBooks.Add(newLogbook);
            return await this.context.SaveChangesAsync();
        }
    }
}
