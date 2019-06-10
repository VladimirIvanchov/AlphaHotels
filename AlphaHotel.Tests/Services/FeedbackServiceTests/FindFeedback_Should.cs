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
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.Censorship;
using AutoMapper;

namespace AlphaHotel.Tests.Services.FeedbackServiceTests
{
    [TestClass]
    public class FindFeedback_Should
    {
        [TestMethod]
        public async Task FindFeedback_WhenFeedbackIsFound()
        {
            var id = 1;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();
            var mapperMocked = new Mock<IConfigurationProvider>();

            FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedback(nameof(FindFeedback_WhenFeedbackIsFound), id);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(FindFeedback_WhenFeedbackIsFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);

                var feedback = await feedbackService.FindFeedback(id);

                Assert.AreEqual(id, feedback.Id);
            }
        }

        [TestMethod]
        public async Task FindFeedback_WhenFeedbackIsNotFound()
        {
            var id = 1;
            var wrongId = 2;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedback(nameof(FindFeedback_WhenFeedbackIsNotFound), id);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(FindFeedback_WhenFeedbackIsNotFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);

                var feedback = await feedbackService.FindFeedback(wrongId);

                Assert.AreEqual(null, feedback);
            }
        }
    }
}
