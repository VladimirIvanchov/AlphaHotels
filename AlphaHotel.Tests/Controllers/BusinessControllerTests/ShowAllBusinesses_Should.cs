using AlphaHotel.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using AlphaHotel.DTOs;
using AlphaHotel.Controllers;
using Microsoft.AspNetCore.Mvc;
using AlphaHotel.Infrastructure.PagingProvider;

namespace AlphaHotel.Tests.Controllers.BusinessControllerTests
{
    [TestClass]
    public class ShowAllBusinesses_Should
    {
        [TestMethod]
        public async Task CallBusinessServiceListAllBusinessesByPageAsyncOnce()
        {
            var pageNumber = 1;
            var pageSize = 9;
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var businessShortInfoDTO = new BusinessShortInfoDTO { Name = businessName };
            var pageList = new PaginatedList<BusinessShortInfoDTO> { businessShortInfoDTO };

            businessServiceMocked.Setup(b => b.ListAllBusinessesByPageAsync(pageNumber, pageSize))
                                 .ReturnsAsync(pageList);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            await businessController.ShowAllBusinesses(pageNumber);

            businessServiceMocked.Verify(b => b.ListAllBusinessesByPageAsync(pageNumber, pageSize), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var pageNumber = 1;
            var pageSize = 9;
            var businessName = "Hilton";

            var businessServiceMocked = new Mock<IBusinessService>();
            var feedbackServiceMocked = new Mock<IFeedbackService>();
            var loggerFactoryMocked = new Mock<ILoggerFactory>();
            var businessShortInfoDTO = new BusinessShortInfoDTO { Name = businessName };
            var pageList = new PaginatedList<BusinessShortInfoDTO> { businessShortInfoDTO };

            businessServiceMocked.Setup(b => b.ListAllBusinessesByPageAsync(pageNumber, pageSize))
                                 .ReturnsAsync(pageList);

            var businessController = new BusinessController(businessServiceMocked.Object, feedbackServiceMocked.Object, loggerFactoryMocked.Object);

            var vm = await businessController.ShowAllBusinesses(pageNumber) as ViewResult;

            Assert.IsInstanceOfType(vm.Model, typeof(PaginatedList<BusinessShortInfoDTO>));
        }
    }
}
