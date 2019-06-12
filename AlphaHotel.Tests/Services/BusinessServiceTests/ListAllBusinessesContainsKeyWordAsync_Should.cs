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
    public class ListAllBusinessesContainsKeyWordAsync_Should
    {
        [TestMethod]
        public async Task ReturnBusinesses_ContainingKeyword()
        {
            var businessId = 1;
            var businessName = "business";
            var keyword = "busi";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            BusinessTestUtils.GetContextWithBusiness(nameof(ReturnBusinesses_ContainingKeyword), businessId, businessName);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(ReturnBusinesses_ContainingKeyword))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var businesses = await businessService.ListAllBusinessesContainsKeyWordAsync(keyword);

                Assert.AreEqual(1, businesses.Count);
            }
        }
    }
}
