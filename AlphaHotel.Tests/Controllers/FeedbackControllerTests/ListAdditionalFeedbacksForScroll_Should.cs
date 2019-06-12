using AlphaHotel.Controllers;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Controllers.FeedbackControllerTests
{
    [TestClass]
    public class ListAdditionalFeedbacksForScroll_Should
    {
        [TestMethod]
        public async Task CallFeedbackServiceOnce()
        {
            var businessId = 1;
            var pageNumber = 1;
            var pageSize = 5;

            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var feedbackController = new FeedbackController(feedbackServiceMocked.Object);

            await feedbackController.ListAdditionalFeedbacksForScroll(businessId, pageNumber);

            feedbackServiceMocked.Verify(f => f.ListAllFeedbacksForUserAsync(businessId, pageNumber, pageSize), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var businessId = 1;
            var pageNumber = 1;

            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var feedbackController = new FeedbackController(feedbackServiceMocked.Object);

            var result = await feedbackController.ListAdditionalFeedbacksForScroll(businessId, pageNumber) as PartialViewResult;

            Assert.AreEqual(result.ViewName, "_AdditionalFeedbacks");
        }
    }
}
