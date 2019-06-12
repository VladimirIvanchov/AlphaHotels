using System;
using System.Threading.Tasks;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlphaHotel.Controllers
{
    public class BusinessController : Controller
    {
        private const int pageSize = 9;
        private const int feedbacksCount = 4;
        private readonly IBusinessService businessService;
        private readonly IFeedbackService feedbackService;
        private readonly ILoggerFactory logger;

        public BusinessController(IBusinessService businessService, IFeedbackService feedbackService, ILoggerFactory logger)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
            this.feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IActionResult> Details(int id)
        {
            var vm = await this.businessService.FindDetaliedBusinessAsync(id, feedbacksCount);
            //var log = this.logger.CreateLogger("BusinessController");
            //log.LogInformation("Error", "Test");
            return View(vm);
        }

        public async Task<IActionResult> ShowAllBusinesses(int? pageNumber)
        {
            var vm = await this.businessService.ListAllBusinessesByPageAsync(pageNumber, pageSize);

            return View(vm);
        }

        public async Task<IActionResult> FindBusiness([FromQuery(Name = "keyword")] string keyword)
        {
            var businesses = await this.businessService.ListAllBusinessesContainsKeyWordAsync(keyword ?? "".ToLower());

            return Json(businesses);
        }

        [HttpPost]
        public async Task<IActionResult> SendFeedback(SendFeedbackViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //var log = this.logger.CreateLogger("BusinessController");
                //log.LogInformation("Error", "Test");
                return BadRequest("Invalid parameters");
            }

            try
            {
                await this.feedbackService.AddFeedbackAsync(model.FeedbackText, model.Rating, model.Author, model.BusinessId);

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