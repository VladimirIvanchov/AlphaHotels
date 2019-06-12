using AlphaHotel.Controllers;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Net;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Controllers.BusinessControllerTests
{
    [TestClass]
    public class SendFeedback_Should
    {
        [TestMethod]
        public async Task ReturnBadRequest_WhenModelIsInvalid()
        {
            string feedbackText = null;
            var rating = 5;
            var author = "IvanchoIvanchoIvanchoIvanchoIvanchoIvanchoIvancho";
            var businessId = 1;

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var sendFeedbackViewModel = new SendFeedbackViewModel
            {
                FeedbackText = feedbackText,
                Rating = rating,
                Author = author,
                BusinessId = businessId
            };

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);
            businessController.ModelState.AddModelError("test", "test");
            var result = await businessController.SendFeedback(sendFeedbackViewModel);

            Assert.AreEqual(result.GetType(), typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task CallBusinessServiceOnce_WhenModelIsValid()
        {
            var feedbackText = "test";
            var rating = 5;
            var author = "Ivancho";
            var businessId = 1;

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var sendFeedbackViewModel = new SendFeedbackViewModel
            {
                FeedbackText = feedbackText,
                Rating = rating,
                Author = author,
                BusinessId = businessId
            };

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            await businessController.SendFeedback(sendFeedbackViewModel);

            feedbackServiceMocked.Verify(f => f.AddFeedbackAsync(feedbackText, rating, author, businessId), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewResult()
        {
            var feedbackText = "test";
            var rating = 5;
            var author = "Ivancho";
            var businessId = 1;

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var sendFeedbackViewModel = new SendFeedbackViewModel
            {
                FeedbackText = feedbackText,
                Rating = rating,
                Author = author,
                BusinessId = businessId
            };

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            var result = await businessController.SendFeedback(sendFeedbackViewModel);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}
