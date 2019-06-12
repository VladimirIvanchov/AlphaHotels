using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Admin.Models;
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
    public class EditAccountPost_Should
    {
        [TestMethod]
        public async Task ReturnBadRequest_WhenModelIsInvalid()
        {
            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountVM = new AccountViewModel();

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);
            accountController.ModelState.AddModelError("test", "test");
            var result = await accountController.EditAccount(accountVM);

            Assert.AreEqual(result.GetType(), typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task CallAccountServiceOnce_WhenModelIsValid()
        {
            var id = "test";
            var username = "Ivancho";
            var mail = "ala@bala.com";
            var isDeleted = false;
            var logBookId = new List<int> { 1 };

            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountVM = new AccountViewModel
            {
                Id = id,
                UserName = username,
                Email = mail,
                IsDeleted = isDeleted,
                LogBookId = logBookId
            };

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            await accountController.EditAccount(accountVM);

            accountServiceMocked.Verify(a => a.EditAccountAsync(id, username, mail, isDeleted, logBookId), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewResult()
        {
            var id = "test";
            var username = "Ivancho";
            var mail = "ala@bala.com";
            var isDeleted = false;
            var logBookId = new List<int> { 1 };

            var accountServiceMocked = new Mock<IAccountService>();
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var accountVM = new AccountViewModel
            {
                Id = id,
                UserName = username,
                Email = mail,
                IsDeleted = isDeleted,
                LogBookId = logBookId
            };

            var accountController = new AccountController(accountServiceMocked.Object, businessServiceMocked.Object, mapperMocked.Object);

            var result = await accountController.EditAccount(accountVM);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}
