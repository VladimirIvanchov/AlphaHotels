using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Moderator.Controllers;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.PagingProvider;
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
    public class ListAllFeedbacks_Should
    {
        //[TestMethod]
        //public async Task CallFeedbackService_ListAllFeedbacksForModeratorAsync_AsyncOnce()
        //{
        //    var pageNumber = 1;
        //    var pageSize = 2;
        //    var moderatorId = "moderatorId";

        //    var userHelperMocked = new Mock<IUserHelper>();
        //    var feedbackServiceMocked = new Mock<IFeedbackService>();
        //    var paginatedList = new PaginatedList {}

        //    feedbackServiceMocked.Setup(b => b.ListAllFeedbacksForModeratorAsync(moderatorId, pageNumber, pageSize))
        //                         .ReturnsAsync(businessDetailsDTO);

        //    var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);

        //    await feedbackController.ListAllFeedbacks(pageNumber);

        //    feedbackServiceMocked.Verify(b => b.ListAllFeedbacksForModeratorAsync(moderatorId, pageNumber, pageSize), Times.Once);
        //}

        //[TestMethod]
        //public async Task ReturnCorrectViewResult()
        //{
        //    var pageNumber = 1;

        //    var feedbackServiceMocked = new Mock<IFeedbackService>();
        //    var userHelperMocked = new Mock<IUserHelper>();

        //    var feedbackController = new FeedbackController(feedbackServiceMocked.Object, userHelperMocked.Object);

        //    var result = await feedbackController.ListAllFeedbacks(pageNumber) as ViewResult;

        //    Assert.IsInstanceOfType(result, typeof(IPaginatedList<FeedbackDTO>));
        //}
    }
}
