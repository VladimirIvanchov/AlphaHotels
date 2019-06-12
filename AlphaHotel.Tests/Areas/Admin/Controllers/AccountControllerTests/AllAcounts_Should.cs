using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Admin.Controllers.AccountControllerTests
{
    [TestClass]
    public class AllAcounts_Should
    {
        [TestMethod]
        public async Task CallAccountServiceOnce()
        {
            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            await accountController.AllAcounts();

            accountServiceMocked.Verify(a => a.ListAllUsersAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountDTO = new AccountDTO { BusinessId = 1 };
            var accountDTOs = new List<AccountDTO> { accountDTO };

            accountServiceMocked.Setup(a => a.ListAllUsersAsync())
                .ReturnsAsync(accountDTOs);

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            var result = await accountController.AllAcounts() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(List<AccountDTO>));
        }
    }
}
