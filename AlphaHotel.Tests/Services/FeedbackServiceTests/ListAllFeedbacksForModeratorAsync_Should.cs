using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Tests.TestUtils;
using AlphaHotel.Data;
using AlphaHotel.Models;
using Moq;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.Censorship;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.Services.FeedbackServiceTests
{
    [TestClass]
    public class ListAllFeedbacksForModeratorAsync_Should
    {
        [TestMethod]
        public async Task ListAllFeedbacksForModeratorAsync_ReturnNull_WhenModeratorIsNotFound()
        {
            var businessId = 1;
            var feedbackId = 1;

            var moderatorId = "moderatorId";
            var wrongModeratorId = "wrondModeratorId";
            var pageNumber = 1;
            var pageSize = 2;

            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            //FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedbackIdAndBusinessAndModerator(nameof(ListAllFeedbacksForModeratorAsync_ReturnNull_WhenModeratorIsNotFound), feedbackId, moderatorId, businessId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ListAllFeedbacksForModeratorAsync_ReturnNull_WhenModeratorIsNotFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                var feedbacks = await feedbackService.ListAllFeedbacksForModeratorAsync(wrongModeratorId, pageNumber, pageSize);

                Assert.AreEqual(null, feedbacks);
            }
        }

        [TestMethod]
        public async Task ListAllFeedbacksForModeratorAsync_ReturnFeedbacks_WhenModeratorIsFound()
        {
            var businessId = 1;
            var feedbackId = 1;

            var moderatorId = "moderatorId";

            var pageNumber = 1;
            var pageSize = 2;

            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            //FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedbackIdAndBusinessAndModerator(nameof(ListAllFeedbacksForModeratorAsync_ReturnFeedbacks_WhenModeratorIsFound), feedbackId, moderatorId, businessId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ListAllFeedbacksForModeratorAsync_ReturnFeedbacks_WhenModeratorIsFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                var feedbacks = await feedbackService.ListAllFeedbacksForModeratorAsync(moderatorId, pageNumber, pageSize);

                Assert.AreEqual(1, feedbacks);
            }
        }
    }
}