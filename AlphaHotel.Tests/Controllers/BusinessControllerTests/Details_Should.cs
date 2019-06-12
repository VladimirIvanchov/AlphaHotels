using AlphaHotel.Controllers;
using AlphaHotel.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AlphaHotel.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Tests.Controllers.BusinessControllerTests
{
    [TestClass]
    public class Details_Should
    {
        [TestMethod]
        public async Task CallBusinessServiceFindDetaliedBusinessAsyncOnce()
        {
            var id = 1;
            var feedbacksCount = 4;
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILogger<BusinessController>>();
            var businessDetailsDTO = new BusinessDetailsDTO { Name = businessName };

            businessServiceMocked.Setup(b => b.FindDetaliedBusinessAsync(id, feedbacksCount))
                                 .ReturnsAsync(businessDetailsDTO);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            await businessController.Details(id);

            businessServiceMocked.Verify(b => b.FindDetaliedBusinessAsync(id, feedbacksCount), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var id = 1;
            var feedbacksCount = 4;
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILogger<BusinessController>>();
            var businessDetailsDTO = new BusinessDetailsDTO { Name = businessName };

            businessServiceMocked.Setup(b => b.FindDetaliedBusinessAsync(id, feedbacksCount))
                                 .ReturnsAsync(businessDetailsDTO);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            var vm = await businessController.Details(id) as ViewResult;

            Assert.IsInstanceOfType(vm.Model, typeof(BusinessDetailsDTO));
        }
    }
}
