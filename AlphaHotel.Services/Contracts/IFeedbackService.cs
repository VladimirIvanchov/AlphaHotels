﻿using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
using System.Threading.Tasks;

namespace AlphaHotel.Services.Contracts
{
    public interface IFeedbackService
    {
        Task<IPaginatedList<FeedbackDTO>> ListAllFeedbacksAsync(string moderatorId, int? pageNumber, int pageSize);
        Task<FeedbackDTO> FindFeedback(int feedbackId);
        Task<int> EditFeedback(int feedbackId, string author, string text, int rate, bool isDeleted);
    }
}
