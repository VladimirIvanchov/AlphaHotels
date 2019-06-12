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
    public class GetLogBooksAndCategories_Should
    {
        [TestMethod]
        public async Task GetLogBooksAndCategories_ThrowException_WhenUserIsNotFound()
        {
            var userId = "userId";

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();


            LogBookTestUtils.ResetAutoMapper();
            LogBookTestUtils.InitializeAutoMapper();
            //LogBookTestUtils.GetContextWithLog(nameof(GetLogBooksAndCategories_ThrowException_WhenUserIsNotFound), logId);

            using (var assertContext = new AlphaHotelDbContext(LogBookTestUtils.GetOptions(nameof(GetLogBooksAndCategories_ThrowException_WhenUserIsNotFound))))
            {
                var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await logbookService.GetLogBooksAndCategories(userId));
            }
        }

        //[TestMethod]
        //public async Task GetLogBooksAndCategories_ThrowException_WhenUserIsNotInRole()
        //{
        //    var userId = "userId";
        //    var role = "manager";

        //    var mappingProviderMocked = new Mock<IMappingProvider>();
        //    var paginatedListMocked = new Mock<IPaginatedList<LogDTO>>();
        //    var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
        //    var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();


        //    LogBookTestUtils.ResetAutoMapper();
        //    LogBookTestUtils.InitializeAutoMapper();
        //    LogBookTestUtils.GetContextWithUser(nameof(GetLogBooksAndCategories_ThrowException_WhenUserIsNotInRole), userId);

        //    using (var assertContext = new AlphaHotelDbContext(LogBookTestUtils.GetOptions(nameof(GetLogBooksAndCategories_ThrowException_WhenUserIsNotInRole))))
        //    {
        //        var logbookService = new LogBookService(assertContext, mappingProviderMocked.Object, paginatedListMocked.Object, dateTimeWrapperMocked.Object, userManagerWrapperMocked.Object);

        //        await Assert.ThrowsExceptionAsync<ArgumentException>(
        //            async () => await logbookService.GetLogBooksAndCategories(userId));
        //    }
        //}


    }
}
