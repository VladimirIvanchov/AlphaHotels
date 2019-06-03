using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Services.Contracts;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly AlphaHotelDbContext context;
        private readonly IPaginatedList<FeedbackDTO> paginatedList;

        public FeedbackService(AlphaHotelDbContext context, IPaginatedList<FeedbackDTO> paginatedList)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.paginatedList = paginatedList ?? throw new ArgumentNullException(nameof(paginatedList));
        }

        public async Task<IPaginatedList<FeedbackDTO>> ListAllFeedbacksAsync(string moderatorId, int? pageNumber, int pageSize)
        {
            var businessId = await this.context.Users
                .Where(u => u.Id == moderatorId)
                .Select(u => u.BusinessId)
                .FirstOrDefaultAsync();

            var feedbackQuery = this.context.Feedbacks
                .Where(f => f.Business.Id == businessId)
                .ProjectTo<FeedbackDTO>();

            return await this.paginatedList.CreateAsync(feedbackQuery, pageNumber ?? 1, pageSize, "");
        }
    }
}
