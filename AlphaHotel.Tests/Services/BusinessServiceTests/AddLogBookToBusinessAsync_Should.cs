using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Tests.TestUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Services.BusinessServiceTests
{
    [TestClass]
    public class AddLogBookToBusinessAsync_Should
    {
        [TestMethod]
        public async Task AddLogBookToBusinessAsync_ThrowException_WhenLogBookAlreadyExists()
        {
            var logbookName = "logbook";
            var businessId = 1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.GetContextWithBusinessAndLogBook(nameof(AddLogBookToBusinessAsync_ThrowException_WhenLogBookAlreadyExists), businessId, logbookName);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(AddLogBookToBusinessAsync_ThrowException_WhenLogBookAlreadyExists))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await businessService.AddLogBookToBusinessAsync(logbookName, businessId));
            }
        }

        [TestMethod]
        public async Task AddLogBookToBusinessAsync_Return_WhenLogBookIsAdded()
        {
            var logbookName = "logbook";
            var businessId = 1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            //BusinessTestUtils.GetContextWithCategory(nameof(AddCategory_Return_WhenCategoryAllParametersArePassed), categoryName);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(AddLogBookToBusinessAsync_Return_WhenLogBookIsAdded))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                await businessService.AddLogBookToBusinessAsync(logbookName, businessId);

                var business = await assertContext.Businesses.FirstOrDefaultAsync(b => b.Id == businessId);
                var logbook = await assertContext.LogBooks.FirstOrDefaultAsync(lb => lb.BusinessId == businessId);

                Assert.AreEqual(logbookName, logbook.Name);
                Assert.AreEqual(businessId, logbook.BusinessId);
            }
        }
    }
}
