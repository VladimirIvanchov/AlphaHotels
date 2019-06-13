using AlphaHotel.Areas.Moderator.Controllers;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Moderator.Controllers.FeedbackControllerTests
{
    [TestClass]
    public class EditFeedbackGet_Should
    {
        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var feedbackId = 1;

            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var userHelperMocked = new Mock<IUserHelper>();
            var feedbackDTO = new FeedbackDTO { Id = feedbackId };

            feedbackServiceMocked.Setup(b => b.FindFeedback(feedbackId))
                                 .ReturnsAsync(feedbackDTO);

            var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);

            var vm = await feedbackController.EditFeedback(feedbackId) as ViewResult;

            Assert.IsInstanceOfType(vm.Model, typeof(FeedbackDTO));
        }

        [TestMethod]
        public async Task CallFeedbackServiceOnce()
        {
            var feedbackId = 1;

            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var userHelperMocked = new Mock<IUserHelper>();
            var feedbackDTO = new FeedbackDTO { Id = feedbackId };

            feedbackServiceMocked.Setup(b => b.FindFeedback(feedbackId))
                                 .ReturnsAsync(feedbackDTO);

            var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);

            await feedbackController.EditFeedback(feedbackId);

            feedbackServiceMocked.Verify(f => f.FindFeedback(feedbackId), Times.Once);
        }
    }
}
