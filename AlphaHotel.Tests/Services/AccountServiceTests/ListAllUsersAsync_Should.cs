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
using Microsoft.EntityFrameworkCore;

namespace AlphaHotel.Tests.Services.AccountServiceTests
{
    [TestClass]
    public class ListAllUsersAsync_Should
    {
        //[TestMethod]
        //public async Task ListAllUsersAsync_ReturnUsers()
        //{
        //    var userId = "userId";

        //    var userManagerWrapperMocked = new Mock<IUserManagerWrapper<User>>();
        //    var mappingProviderMocked = new Mock<IMappingProvider>();
        //    var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();

        //    AccountTestUtils.ResetAutoMapper();
        //    AccountTestUtils.InitializeAutoMapper();
        //    AccountTestUtils.GetContextWithUser(nameof(ListAllUsersAsync_ReturnUsers), userId);

        //    using (var assertContext = new AlphaHotelDbContext(AccountTestUtils.GetOptions(nameof(ListAllUsersAsync_ReturnUsers))))
        //    {
        //        var accountService = new AccountService(assertContext, userManagerWrapperMocked.Object, mappingProviderMocked.Object, dateTimeWrapperMocked.Object);
        //        var users = await accountService.ListAllUsersAsync();

        //        Assert.AreEqual(1, users.Count);
        //    }
        //}
    }
}
