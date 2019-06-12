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
    public class AddLog_Should
    {
        [TestMethod]
        public async Task AddLog_ThrowException_WhenLogBookIsNotFound()
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

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(AddLog_ThrowException_WhenLogBookIsNotFound))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.AddLog(logbookId, userId, description, categoryId));
            }
        }

        [TestMethod]
        public async Task AddLog_ReturnLogDTO_WhenAllParametersArePassed()
        {
            var logbookId = 1;
            var userId = "userId";
            var description = "description";
            var categoryId = 1;
            var username = "gosho";
            var statusId = 1;
            var status = "todo";
            var category = "category";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithFullLogAndLogBookAndUserAndStatusAndCategory(nameof(AddLog_ReturnLogDTO_WhenAllParametersArePassed), logbookId, userId, categoryId, description, username, statusId, status, category);

            using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(AddLog_ReturnLogDTO_WhenAllParametersArePassed))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                var logDto = await logbookService.AddLog(logbookId, userId, description, categoryId);

                var log = await assertContext.Logs.FirstOrDefaultAsync(l => l.LogBookId == logbookId);

                Assert.AreEqual(log.Id, logDto.Id);
                Assert.AreEqual(log.LogBookId, logDto.LogBookId);
                Assert.AreEqual(log.Author.UserName, logDto.AuthorUsername);
                Assert.AreEqual(log.Category.Name, logDto.Category);
                Assert.AreEqual(log.Description, logDto.Description);
                Assert.AreEqual(log.StatusId, logDto.StatusId);
                Assert.AreEqual(log.CreatedOn, logDto.CreatedOn);
                Assert.IsFalse(logDto.IsDeleted);
            }
        }
    }
}
