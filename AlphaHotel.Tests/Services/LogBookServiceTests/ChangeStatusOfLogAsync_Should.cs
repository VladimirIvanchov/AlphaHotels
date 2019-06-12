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
    public class ChangeStatusOfLogAsync_Should
    {
        [TestMethod]
        public async Task ChangeStatusOfLogAsync_ThrowException_WhenLogIsNotFound()
        {
            var logId = 1;
            var statusId = 1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            //LogBookTestUtils.GetContextWithLog(nameof(AddLog_ThrowException_WhenLogBookIsNotFound), logId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ChangeStatusOfLogAsync_ThrowException_WhenLogIsNotFound))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.ChangeStatusOfLogAsync(statusId, logId));
            }
        }

        [TestMethod]
        public async Task ChangeStatusOfLogAsync_ThrowException_WhenStatusIdIsSmallerThanZero()
        {
            var logId = 1;
            var statusId = -1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithLogAndStatuses(nameof(ChangeStatusOfLogAsync_ThrowException_WhenStatusIdIsSmallerThanZero), logId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ChangeStatusOfLogAsync_ThrowException_WhenStatusIdIsSmallerThanZero))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.ChangeStatusOfLogAsync(statusId, logId));
            }
        }

        [TestMethod]
        public async Task ChangeStatusOfLogAsync_ThrowException_WhenStatusIdIsLargerThanStatusesCount()
        {
            var logId = 1;
            var statusId = 5;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithLogAndStatuses(nameof(ChangeStatusOfLogAsync_ThrowException_WhenStatusIdIsLargerThanStatusesCount), logId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ChangeStatusOfLogAsync_ThrowException_WhenStatusIdIsLargerThanStatusesCount))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);
                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.ChangeStatusOfLogAsync(statusId, logId));
            }
        }

        [TestMethod]
        public async Task ChangeStatusOfLogAsync_Return_WhenStatusIsChanged()
        {
            var logId = 1;
            var oldStatusId = 1;
            var newStatusId = 2;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithLogAndStatuses(nameof(ChangeStatusOfLogAsync_Return_WhenStatusIsChanged), logId, oldStatusId, newStatusId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ChangeStatusOfLogAsync_Return_WhenStatusIsChanged))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                var log = await assertContext.Logs.FirstOrDefaultAsync(l => l.StatusId == oldStatusId);
                await logbookService.ChangeStatusOfLogAsync(newStatusId, logId);


                Assert.AreEqual(newStatusId, log.StatusId);
            }
        }
    }
}
