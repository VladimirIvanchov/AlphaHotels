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
    public class FindDetaliedBusinessAsync_Should
    {
        [TestMethod]
        public async Task ThrowException_WhenBusinessIsNotFound()
        {
            var businessId = 1;
            var wrongBusinessId = 2;
            var feedbacksCount = 1;

            var feedbackRating = 5;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusinessAndFeedback(nameof(ThrowException_WhenBusinessIsNotFound), businessId, feedbackRating);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(ThrowException_WhenBusinessIsNotFound))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await businessService.FindDetaliedBusinessAsync(wrongBusinessId, feedbacksCount));
            }
        }

        [TestMethod]
        public async Task FindDetailedBusinessAsync_ReturnBusinesses()
        { 
            var businessId = 1;
            var feedbackCount = 1;
            var feedbackRating = 5;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusinessAndFeedback(nameof(FindDetailedBusinessAsync_ReturnBusinesses), businessId, feedbackRating);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(FindDetailedBusinessAsync_ReturnBusinesses))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var business = await businessService.FindDetaliedBusinessAsync(businessId, feedbackCount);

                Assert.AreEqual(feedbackCount, business.Feedbacks.Count);
            }
        }
    }
}
