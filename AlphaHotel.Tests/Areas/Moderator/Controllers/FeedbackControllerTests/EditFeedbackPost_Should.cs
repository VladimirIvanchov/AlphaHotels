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
    public class EditFeedbackPost_Should
    {
        [TestMethod]
        public async Task ReturnBadRequest_WhenModelIsInvalid()
        {
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var userHelperMocked = new Mock<IUserHelper>();
            var feedbackDTO = new FeedbackDTO();

            var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);
            feedbackController.ModelState.AddModelError("test", "test");
            var result = await feedbackController.EditFeedback(feedbackDTO);

            Assert.AreEqual(result.GetType(), typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task CallAccountServiceOnce_WhenModelIsValid()
        {
            var id = 1;
            var text = "text";
            var author = "pesho";
            var isDeleted = false;
            var rating = 5;
            var businessId = 1;

            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var userHelperMocked = new Mock<IUserHelper>();
            var feedbackDTO = new FeedbackDTO()
            {
                Id = id,
                Text = text,
                Author = author,
                IsDeleted = isDeleted,
                Rate = rating,
                BusinessId = businessId
            };

            var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);

            await feedbackController.EditFeedback(feedbackDTO);

            feedbackServiceMocked.Verify(a => a.EditFeedback(id, author, text, rating, isDeleted), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewResult()
        {
            var id = 1;
            var text = "text";
            var author = "pesho";
            var isDeleted = false;
            var rating = 5;
            var businessId = 1;

            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var userHelperMocked = new Mock<IUserHelper>();
            var feedbackDTO = new FeedbackDTO()
            {
                Id = id,
                Text = text,
                Author = author,
                IsDeleted = isDeleted,
                Rate = rating,
                BusinessId = businessId
            };

            var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);

            var result = await feedbackController.EditFeedback(feedbackDTO);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}
