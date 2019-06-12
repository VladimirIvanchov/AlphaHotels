using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Admin.Controllers.AccountControllerTests
{
    [TestClass]
    public class EditAccountGet_Should
    {
        [TestMethod]
        public async Task CallAccountServiceOnce()
        {
            var accountId = "test";
            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountDTO = new AccountDetailsDTO { Role = "Manager" };
            var accountVM = new AccountViewModel();

            accountServiceMocked.Setup(a => a.FindAccountAsync(accountId))
                .ReturnsAsync(accountDTO);

            mapperMocked.Setup(m => m.MapTo<AccountViewModel>(accountDTO))
                .Returns(accountVM);

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            await accountController.EditAccount(accountId);

            accountServiceMocked.Verify(a => a.FindAccountAsync(accountId), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_WhenRoleIsManager()
        {
            var accountId = "test";
            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountDTO = new AccountDetailsDTO { Role = "Manager" };
            var accountVM = new AccountViewModel();

            accountServiceMocked.Setup(a => a.FindAccountAsync(accountId))
                .ReturnsAsync(accountDTO);

            mapperMocked.Setup(m => m.MapTo<AccountViewModel>(accountDTO))
                .Returns(accountVM);

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            var result = await accountController.EditAccount(accountId) as ViewResult;

            businessServiceMocked.Verify(b => b.ListBusinessLogbooksAsync(0), Times.Once);
            Assert.IsInstanceOfType(result.Model, typeof(AccountViewModel));
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel_WhenRoleIsNotManager()
        {
            var accountId = "test";
            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountDTO = new AccountDetailsDTO { Role = "Admin" };
            var accountVM = new AccountViewModel();

            accountServiceMocked.Setup(a => a.FindAccountAsync(accountId))
                .ReturnsAsync(accountDTO);

            mapperMocked.Setup(m => m.MapTo<AccountViewModel>(accountDTO))
                .Returns(accountVM);

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            var result = await accountController.EditAccount(accountId) as ViewResult;

            businessServiceMocked.Verify(b => b.ListBusinessLogbooksAsync(0), Times.Never);
            Assert.IsInstanceOfType(result.Model, typeof(AccountViewModel));
        }
    }
}
