using AlphaHotel.Controllers;
using AlphaHotel.DTOs;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Controllers.BusinessControllerTests
{
    [TestClass]
    public class FindBusiness_Should
    {
        [TestMethod]
        public async Task CallBusinessServiceListAllBusinessesContainsKeyWordAsyncOnce_WhenKeywordExists()
        {
            var keyword = "test";
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var businessDTO = new BusinessDTO { Name = businessName };
            var businesses = new List<BusinessDTO> { businessDTO };

            businessServiceMocked.Setup(b => b.ListAllBusinessesContainsKeyWordAsync(keyword))
                                 .ReturnsAsync(businesses);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            await businessController.FindBusiness(keyword);

            businessServiceMocked.Verify(b => b.ListAllBusinessesContainsKeyWordAsync(keyword), Times.Once);
        }

        [TestMethod]
        public async Task CallBusinessServiceListAllBusinessesContainsKeyWordAsyncOnce_WhenKeywordIsNull()
        {
            string keyword = null;
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var businessDTO = new BusinessDTO { Name = businessName };
            var businesses = new List<BusinessDTO> { businessDTO };

            businessServiceMocked.Setup(b => b.ListAllBusinessesContainsKeyWordAsync(keyword))
                                 .ReturnsAsync(businesses);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            await businessController.FindBusiness(keyword);

            businessServiceMocked.Verify(b => b.ListAllBusinessesContainsKeyWordAsync(""), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewResult()
        {
            string keyword = null;
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var businessDTO = new BusinessDTO { Name = businessName };
            var businesses = new List<BusinessDTO> { businessDTO };

            businessServiceMocked.Setup(b => b.ListAllBusinessesContainsKeyWordAsync(keyword))
                                 .ReturnsAsync(businesses);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            var result = await businessController.FindBusiness(keyword);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}
