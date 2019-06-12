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
using AutoMapper.Configuration;
using AlphaHotel.Infrastructure.MappingProviders.Mappings;

namespace AlphaHotel.Tests.Services.FeedbackServiceTests
{
    [TestClass]
    public class FindFeedback_Should
    {
        [TestMethod]
        public async Task ReturnFeedback_WhenFeedbackIsFound()
        {
            var id = 1;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.ResetAutoMapper();
            FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedbackId(nameof(ReturnFeedback_WhenFeedbackIsFound), id);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ReturnFeedback_WhenFeedbackIsFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);

                var feedback = await feedbackService.FindFeedback(id);

                Assert.AreEqual(id, feedback.Id);
            }
        }

        [TestMethod]
        public async Task ReturnNull_WhenFeedbackIsNotFound()
        {
            var id = 1;
            var wrongId = 2;
            var paginatedListMocked = new Mock<IPaginatedList<FeedbackDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var censorMocked = new Mock<ICensor>();

            FeedbackTestUtils.ResetAutoMapper();
            FeedbackTestUtils.InitializeAutoMapper();
            FeedbackTestUtils.GetContextWithFeedbackId(nameof(ReturnNull_WhenFeedbackIsNotFound), id);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ReturnNull_WhenFeedbackIsNotFound))))
            {
                var feedbackService = new FeedbackService(assertContext, paginatedListMocked.Object, dateTimeWrapperMocked.Object, censorMocked.Object);

                var feedback = await feedbackService.FindFeedback(wrongId);

                Assert.AreEqual(null, feedback);
            }
        }
    }
}
