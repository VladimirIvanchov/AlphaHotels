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
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlphaHotel.Tests.Services.LogBookServiceTests
{
    [TestClass]
    public class AddLog_Should
    {
        [TestMethod]
        public async Task ThrowException_WhenLogBookIsNotFound()
        {
            var logbookId = 1;
            var userId = "userId";
            var description = "description";
            var categoryId = 1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            //LogBookTestUtils.GetContextWithLog(nameof(AddLog_ThrowException_WhenLogBookIsNotFound), logId);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ThrowException_WhenLogBookIsNotFound))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.AddLog(logbookId, userId, description, categoryId));
            }
        }

        [TestMethod]
        public async Task ReturnLogDTO_WhenAllParametersArePassed()
        {
            var logbookId = 1;
            var userId = "userId";
            var description = "description";
            var categoryId = 1;
            var username = "gosho";
            var statusId = 1;
            var statusType = "todo";
            var categoryName = "category";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            Log mapInput = null;
            mappingProviderMocked.Setup(mpm => mpm.MapTo<LogDTO>(It.IsAny<Log>()))
               .Callback<object>(inputArg => mapInput = inputArg as Log);

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithFullLogAndLogBookAndUserAndStatusAndCategory(nameof(ReturnLogDTO_WhenAllParametersArePassed), logbookId, userId, categoryId, description, username, statusId, statusType, categoryName);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(ReturnLogDTO_WhenAllParametersArePassed))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);
                await logbookService.AddLog(logbookId, userId, description, categoryId);

                var log = await assertContext.Logs.FirstOrDefaultAsync(l => l.LogBookId == logbookId);

                Assert.AreEqual(log.Id, mapInput.Id);
                Assert.AreEqual(log.LogBookId, mapInput.LogBookId);
                Assert.AreEqual(log.Description, mapInput.Description);
                Assert.AreEqual(log.StatusId, mapInput.StatusId);
                Assert.AreEqual(log.CreatedOn, mapInput.CreatedOn);
                Assert.IsFalse(mapInput.IsDeleted);
            }
        }
    }
}
