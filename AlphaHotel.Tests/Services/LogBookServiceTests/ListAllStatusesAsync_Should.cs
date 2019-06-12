using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Infrastructure.Wrappers.Contracts;
using AlphaHotel.Models;
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
namespace AlphaHotel.Tests.Services.LogBookServiceTests
{
    [TestClass]
    public class ListAllStatusesAsync_Should
    {
        [TestMethod]
        public async Task ListAllStatusesAsync_ReturnStatuses()
        {
            var logId = 1;
            var statusId = 1;
            var statusId2 = 2;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithLogAndStatuses(nameof(ListAllStatusesAsync_ReturnStatuses), logId, statusId, statusId2);

            using (var assertContext = new AlphaHotelDbContext(LogBookTestUtils.GetOptions(nameof(ListAllStatusesAsync_ReturnStatuses))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);
                var logbooks = await logbookService.ListAllStatusesAsync();

                Assert.AreEqual(2, logbooks.Count);
            }
        }
    }
}
