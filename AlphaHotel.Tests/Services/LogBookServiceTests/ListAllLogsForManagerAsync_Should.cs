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
    public class ListAllLogsForManagerAsync_Should
    {
        [TestMethod]
        public async Task ListAllLogsForManagerAsync_ReturnPaginatedList()
        {
            var userId = "userId";
            var pageNumber = 1;
            var pageSize = 2;
            var logId = 1;
            var description = "problem with bed";
            var keyword = "problem";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithLog(nameof(ListAllLogsForManagerAsync_ReturnPaginatedList), logId, description);

            using (var assertContext = new AlphaHotelDbContext(LogBookTestUtils.GetOptions(nameof(ListAllLogsForManagerAsync_ReturnPaginatedList))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);
                var logbooks = await logbookService.ListAllLogsForManagerAsync(userId, pageNumber, pageSize, keyword);

                Assert.AreEqual(1, logbooks);
            }
        }
    }
}
