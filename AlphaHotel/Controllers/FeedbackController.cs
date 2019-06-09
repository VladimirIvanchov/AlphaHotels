using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Controllers
{
    public class FeedbackController : Controller
    {
        private const int pageSize = 5;
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));
        }

        public async Task<IActionResult> ListAllFeedbacksForScroll(int businessId, int? pageNumber)
        {
            var feedbacks = await this.feedbackService.ListAllFeedbacksForUserAsync(businessId, pageNumber, pageSize);

            return PartialView("_AllFeedbacks", feedbacks);
        }

        public async Task<IActionResult> ListAdditionalFeedbacksForScroll(int businessId, int? pageNumber)
        {
            var feedbacks = await this.feedbackService.ListAllFeedbacksForUserAsync(businessId, pageNumber, pageSize);

            return PartialView("_AdditionalFeedbacks", feedbacks);
        }
    }
}