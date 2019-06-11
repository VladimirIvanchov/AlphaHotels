using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Tests.TestUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Services.BusinessServiceTests
{
    [TestClass]
    public class ListTopNBusinessesAsync_Should
    {
        [TestMethod]
        public async Task ListTopNBusinessesAsync_ReturnZero_WhenTheBusinessHasNoFeedbacks()
        {
            var count = 0;

            var businessId = 1;
            var feedbackRating = 5;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusinessAndFeedback(nameof(ListTopNBusinessesAsync_ReturnZero_WhenTheBusinessHasNoFeedbacks), businessId, feedbackRating);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ListTopNBusinessesAsync_ReturnZero_WhenTheBusinessHasNoFeedbacks))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var businesses = await businessService.ListTopNBusinessesAsync(count);

                Assert.AreEqual(count, businesses.Count);
            }
        }

        [TestMethod]
        public async Task ListTopNBusinessesAsync_ReturnBusinesses()
        {
            var count = 1;

            var businessId = 1;
            var feedbackRating = 5;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusinessAndFeedback(nameof(ListTopNBusinessesAsync_ReturnBusinesses), businessId, feedbackRating);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(ListTopNBusinessesAsync_ReturnBusinesses))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var businesses = await businessService.ListTopNBusinessesAsync(count);

                Assert.AreEqual(count, businesses.Count);
            }
        }
    }
}
