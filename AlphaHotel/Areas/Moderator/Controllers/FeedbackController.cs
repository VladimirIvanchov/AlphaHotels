using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Common;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Moderator")]
    [Route("[area]/[controller]/[action]")]
    public class FeedbackController : Controller
    {
        private const int pageSize = 2;
        private readonly IFeedbackService feedbackService;
        private readonly IUserHelper userHelper;

        public FeedbackController(IFeedbackService feedbackService, IUserHelper userHelper)
        {
            this.feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));
            this.userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
        }

        public async Task<IActionResult> ListAllFeedbacks(int? pageNumber)
        {
            var moderatorId = this.userHelper.GetId(this.User);
            var feedbacks = await this.feedbackService.ListAllFeedbacksAsync(moderatorId, pageNumber, pageSize);

            return View(feedbacks);
        }
    }
}