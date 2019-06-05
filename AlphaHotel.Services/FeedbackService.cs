using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using AlphaHotel.Services.Utilities;
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
        private readonly IDateTimeWrapper dateTime;

        public FeedbackService(AlphaHotelDbContext context, IPaginatedList<FeedbackDTO> paginatedList, IDateTimeWrapper dateTime)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.paginatedList = paginatedList ?? throw new ArgumentNullException(nameof(paginatedList));
            this.dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
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

        public async Task<FeedbackDTO> FindFeedback(int feedbackId)
        {
            return await this.context.Feedbacks
                .Where(f => f.Id == feedbackId)
                .ProjectTo<FeedbackDTO>()
                .FirstOrDefaultAsync();
        }

        public async Task<int> EditFeedback(int feedbackId, string author, string text, int rate, bool isDeleted )
        {
            var feedback = await this.context.Feedbacks
               .FindAsync(feedbackId);

            if (feedback == null)
            {
                throw new ArgumentException($"Feedback with id {feedbackId} do not exist!");
            }

            feedback.Author = author;
            feedback.Text = text;
            feedback.Rate = rate;
            if (!feedback.IsDeleted && isDeleted)
            {
                feedback.DeletedOn = this.dateTime.Now();
            }

            feedback.IsDeleted = isDeleted;
            feedback.ModifiedOn = this.dateTime.Now();

            return await this.context.SaveChangesAsync();
        }

        public async Task AddFeedbackAsync(string feedbackText, int rating, string author, int businessId)
        {
            var business = await this.context.Businesses.FindAsync(businessId);

            if (business == null)
            {
                throw new ArgumentException($"Hotel with id {businessId} doesn't exist!");
            }

            var feedback = new Feedback()
            {
                Rate = rating,
                BusinessId = businessId,
                CreatedOn = dateTime.Now(),
                Text = feedbackText,
                IsDeleted = false
            };

            if (!string.IsNullOrEmpty(author))
            {
                feedback.Author = author;
            }


            this.context.Feedbacks.Add(feedback);
            await this.context.SaveChangesAsync();
        }
    }
}
