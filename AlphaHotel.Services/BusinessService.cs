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
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.PagingProvider;

namespace AlphaHotel.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly AlphaHotelDbContext context;
        private readonly IMappingProvider mapper;
        private readonly IDateTimeWrapper dateTime;
        private readonly IPaginatedList<BusinessShortInfoDTO> paginatedList;

        public BusinessService(AlphaHotelDbContext context, IMappingProvider mapper, IDateTimeWrapper dateTime, IPaginatedList<BusinessShortInfoDTO> paginatedList)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
            this.paginatedList = paginatedList ?? throw new ArgumentNullException(nameof(paginatedList));
        }

        public async Task<ICollection<T>> ListAllBusinessesAsync<T>()
        {
            var businesses = await this.context.Businesses
                .ProjectTo<T>()
                .ToListAsync();

            return businesses;
        }

        public async Task<IPaginatedList<BusinessShortInfoDTO>> ListAllBusinessesByPageAsync(int? pageNumber, int pageSize)
        {
            var businessesQuery = this.context.Businesses
                .ProjectTo<BusinessShortInfoDTO>();

            return await this.paginatedList.CreateAsync(businessesQuery, pageNumber ?? 1, pageSize, "");
        }

        public async Task<ICollection<BusinessDTO>> ListAllBusinessesContainsKeyWordAsync(string keyword)
        {
            var businesses = await this.context.Businesses
                .Where(b=>b.Name.Contains(keyword))
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

        public async Task<BusinessDTO> CreateBusiness(string name, string location, string about, string shortDescription, string coverPicture, ICollection<string> pictures, ICollection<int> businessFacilities)
        {
            var business = await this.context.Businesses
                .Where(b => b.Name == name)
                .FirstOrDefaultAsync();

            if (business != null)
            {
                throw new ArgumentException($"Business {name} already exist!");
            }

            var newBusiness = new Business()
            {
                Name = name,
                Location = location,
                About = about,
                ShortDescription = shortDescription,
                CoverPicture = coverPicture,
                CreatedOn = this.dateTime.Now()
            };

            newBusiness.Pictures = pictures
                .Select(p => new Picture() { Location = p })
                .ToList();

            newBusiness.BusinessesFacilities = businessFacilities
                .Select(bf => new BusinessesFacilities() { FacilityId = bf })
                .ToList();

            this.context.Add(newBusiness);
            await this.context.SaveChangesAsync();

            return this.mapper.MapTo<BusinessDTO>(newBusiness);
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

        public async Task<BusinessDetailsDTO> FindDetaliedBusinessAsync(int businessId, int feedbacksCount)
        {
            var business = await this.context.Businesses
                .Include(b => b.Pictures)
                .Include(b => b.BusinessesFacilities)
                    .ThenInclude(bf => bf.Facility)
                .ProjectTo<BusinessDetailsDTO>()
                .FirstOrDefaultAsync(b => b.Id == businessId);

            if (business == null)
            {
                throw new ArgumentException($"Business whit id: {businessId} do not exist!");
            }

            var feedbacks = await this.context.Feedbacks
                .Where(f => f.BusinessId == businessId)
                .OrderByDescending(f=>f.Rate)
                .Take(feedbacksCount)
                .ProjectTo<FeedbackForBusinessDTO>()
                .ToListAsync();
            business.Feedbacks = feedbacks;

            return business;
        }

        public async Task<BusinessDetailsDTO> FindDetaliedBusinessByNameAsync(string businessName, int feedbacksCount)
        {
            var business = await this.context.Businesses
                .Include(b => b.Pictures)
                .Include(b => b.BusinessesFacilities)
                    .ThenInclude(bf => bf.Facility)
                .ProjectTo<BusinessDetailsDTO>()
                .FirstOrDefaultAsync(b => b.Name == businessName);

            if (business == null)
            {
                throw new ArgumentException($"Business {business} do not exist!");
            }

            var feedbacks = await this.context.Feedbacks
                .Where(f => f.Business.Name == businessName)
                .OrderByDescending(f => f.Rate)
                .Take(feedbacksCount)
                .ProjectTo<FeedbackForBusinessDTO>()
                .ToListAsync();
            business.Feedbacks = feedbacks;

            return business;
        }

        public async Task<ICollection<BusinessShortInfoDTO>> ListTopNBusinessesAsync(int counts)
        {
            var businesses = await this.context.Businesses
                .Include(b => b.Feedbacks)
                .Where(b => b.Feedbacks.Count != 0)
                .OrderByDescending(b => b.Feedbacks.Average(f => f.Rate))
                .Take(counts)
                .ProjectTo<BusinessShortInfoDTO>()
                .ToListAsync();

            return businesses;
        }
    }
}
