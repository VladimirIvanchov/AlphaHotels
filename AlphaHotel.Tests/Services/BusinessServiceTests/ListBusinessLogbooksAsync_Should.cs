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
    public class ListBusinessLogbooksAsync_Should
    {
        [TestMethod]
        public async Task ListBusinessLogbooksAsync_ReturnLogBooks()
        {
            var businessId = 1;
            var logbookName = "logbook";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusinessAndLogBook(nameof(ListBusinessLogbooksAsync_ReturnLogBooks), businessId, logbookName);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(ListBusinessLogbooksAsync_ReturnLogBooks))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var logbooks = await businessService.ListBusinessLogbooksAsync(businessId);

                Assert.AreEqual(1, logbooks.Count);
            }
        }
    }
}
