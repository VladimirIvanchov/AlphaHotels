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
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Infrastructure.Censorship;
using AlphaHotel.DTOs;
using AutoMapper;

namespace AlphaHotel.Tests.Services.FeedbackServiceTests
{
    [TestClass]
    public class ListAllFeedbacksForUserAsync_Should
    {
        [TestMethod]
        public async Task ListAllFeedbacksForModeratorAsync_Return_WhenUserIsFound()
        {
            var businessId = 1;
            var feedbackId = 1;

            var pageNumber = 1;
            var pageSize = 2;

            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.ResetAutoMapper();
            FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedbackIdAndBusiness(nameof(ListAllFeedbacksForModeratorAsync_Return_WhenUserIsFound), feedbackId, businessId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ListAllFeedbacksForModeratorAsync_Return_WhenUserIsFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);
                var feedbacks = await feedbackService.ListAllFeedbacksForUserAsync(businessId, pageNumber, pageSize);

                Assert.AreEqual(1, feedbacks);
            }
        }
    }
}
