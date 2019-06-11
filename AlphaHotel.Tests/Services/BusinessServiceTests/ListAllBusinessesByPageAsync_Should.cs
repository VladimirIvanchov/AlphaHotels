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
    public class ListAllBusinessesByPageAsync_Should
    {
        [TestMethod]
        public async Task ListAllBusinessesByPageAsync_ReturnPaginatedList()
        {
            var businessId = 1;
            var businessName = "business";

            var pageNumber = 1;
            var pageSize = 2;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusiness(nameof(ListAllBusinessesByPageAsync_ReturnPaginatedList), businessId, businessName);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ListAllBusinessesByPageAsync_ReturnPaginatedList))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var businesses = await businessService.ListAllBusinessesByPageAsync(pageNumber, pageSize);

                Assert.AreEqual(1, businesses);
            }
        }
    }
}
