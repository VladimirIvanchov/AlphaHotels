using AlphaHotel.Data;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.Wrappers.Contracts;
using AlphaHotel.Models;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Tests.TestUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Services.AccountServiceTests
{
    [TestClass]
    public class FindAccountAsync_Should
    {
        //[TestMethod]
        //public async Task FindAccountAsync_ReturnUser_WhenUserIsFound()
        //{
        //    var userId = "userId";

        //    var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();
        //    var mappingProviderMocked = new Mock<IMappingProvider>();
        //    var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();

        //    AccountTestUtils.ResetAutoMapper();
        //    AccountTestUtils.InitializeAutoMapper();
        //    AccountTestUtils.GetContextWithFeedbackId(nameof(FindFeedback_WhenFeedbackIsFound), id);

        //    using (var assertContext = new AlphaHotelDbContext(AccountTestUtils.GetOptions(nameof(FindAccountAsync_ReturnUser_WhenUserIsFound))))
        //    {
        //        var accountService = new AccountService(assertContext, userManagerWrapperMocked.Object, mappingProviderMocked.Object, dateTimeWrapperMocked.Object);

        //        var user = await accountService.FindAccountAsync(userId);

        //        Assert.AreEqual(userId, user.Id);
        //    }
        //}

        //[TestMethod]
        //public async Task FindAccountAsync_ThrowException_WhenFeedbackIsNotFound()
        //{
        //    var userId = "userId";
        //    var wrongUserId = "wrongUserId";

        //    var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();
        //    var mappingProviderMocked = new Mock<IMappingProvider>();
        //    var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();

        //    AccountTestUtils.ResetAutoMapper();
        //    AccountTestUtils.InitializeAutoMapper();
        //    AccountTestUtils.GetContextWithUser(nameof(FindAccountAsync_ThrowException_WhenFeedbackIsNotFound), userId);

        //    using (var assertContext = new AlphaHotelDbContext(FeedbackTestUtils.GetOptions(nameof(FindAccountAsync_ThrowException_WhenFeedbackIsNotFound))))
        //    {
        //        var accountService = new AccountService(assertContext, userManagerWrapperMocked.Object, mappingProviderMocked.Object, dateTimeWrapperMocked.Object);

        //        await Assert.ThrowsExceptionAsync<ArgumentException>(
        //            async () => await accountService.FindAccountAsync(wrongUserId));
        //    }
        //}
    }
}
