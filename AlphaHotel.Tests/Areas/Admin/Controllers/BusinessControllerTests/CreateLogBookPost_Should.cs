using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Admin.Controllers.BusinessControllerTests
{
    [TestClass]
    public class CreateLogBookPost_Should
    {
        [TestMethod]
        public async Task ReturnBadRequest_WhenModelIsInvalid()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var createLogBookViewModel = new CreateLogBookViewModel();

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);
            businessController.ModelState.AddModelError("error", "error");

            var result = await businessController.CreateLogBook(createLogBookViewModel);

            Assert.AreEqual(result.GetType(), typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task CallBusinessServiceOnce()
        {
            var logbookName = "test";
            var businessId = 1;
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var createLogBookViewModel = new CreateLogBookViewModel
            {
                LogBookName = logbookName,
                BusinessId = businessId
            };

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.CreateLogBook(createLogBookViewModel);

            businessServiceMocked.Verify(a => a.AddLogBookToBusinessAsync(logbookName, businessId), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var logbookName = "test";
            var businessId = 1;
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var businessDTOs = new List<BusinessDTO> { new BusinessDTO() };
            var createLogBookViewModel = new CreateLogBookViewModel
            {
                LogBookName = logbookName,
                BusinessId = businessId
            };

            businessServiceMocked.Setup(b => b.ListAllBusinessesAsync<BusinessDTO>())
                .ReturnsAsync(businessDTOs);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            var result = await businessController.CreateLogBook(createLogBookViewModel);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}
