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
    public class FindLog_Should
    {
        [TestMethod]
        public async Task ReturnLogDTO_WhenLogIsFound()
        {
            var logId = 1;
            var description = "description";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            Log mapInput = null;
            mappingProviderMocked.Setup(mpm => mpm.MapTo<LogDTO>(It.IsAny<Log>()))
               .Callback<object>(inputArg => mapInput = inputArg as Log);

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            LogBookTestUtils.GetContextWithLogAndAuthorAndStatusAndCategory(nameof(ReturnLogDTO_WhenLogIsFound), logId, description);

            using (var assertContext = new AlphaHotelDbContext(LogBookTestUtils.GetOptions(nameof(ReturnLogDTO_WhenLogIsFound))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);
                var log = await assertContext.Logs.FirstOrDefaultAsync(l => l.Id == logId);
                await logbookService.FindLog(logId);


                Assert.AreEqual(log.Id, mapInput.Id);
            }
        }

        [TestMethod]
        public async Task ThrowException_WhenLogIsNotFound()
        {
            var logId = 1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();

            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            //LogBookTestUtils.(nameof(FindLog_ThrowException_WhenLogIsNotFound));

            using (var assertContext = new AlphaHotelDbContext(LogBookTestUtils.GetOptions(nameof(ThrowException_WhenLogIsNotFound))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.FindLog(logId));
            }
        }
    }
}
