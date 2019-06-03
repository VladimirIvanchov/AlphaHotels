using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
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

        [HttpGet]
        public async Task<IActionResult> EditFeedback(int feedbackId)
        {
            var feedback = await this.feedbackService.FindFeedback(feedbackId);
            return View(feedback);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFeedback(FeedbackDTO model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid parameters!");
            }

            try
            {
                await this.feedbackService.EditFeedback(model.Id, model.Author, model.Text, model.Rate, model.IsDeleted);

                return Json(model);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}