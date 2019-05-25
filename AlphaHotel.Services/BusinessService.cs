using AlphaHotel.Data;
using AlphaHotel.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AlphaHotel.ViewModels;
using AlphaHotel.Infrastructure.MappingProviders;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ICollection<BusinessViewModel>> ListAllBusinesses()
        {
            var businesses = await this.context.Businesses
                .Select(b => new BusinessViewModel
                {
                    BusinessId = b.Id,
                    Name = b.Name
                })
                .ToListAsync();

            //var businesses = await this.context.Businesses
            //   .Select(b => new { b.Name, b.Id })
            //   .ToListAsync();

            //var mapped = this.mapper.MapTo<ICollection<BusinessViewModel>>(businesses);

            //var result = await this.context.Businesses
            //    .ProjectTo<BusinessViewModel>()
            //    .ToListAsync();

            return businesses;
        }

        public async Task<ICollection<LogBookViewModel>> ListBusinessLogbooks(int id)
        {
            var businesses = await this.context.LogBooks
                .Where(l=>l.BusinessId == id)
                .Select(b => new LogBookViewModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
                .ToListAsync();

            return businesses;
        }
    }
}
