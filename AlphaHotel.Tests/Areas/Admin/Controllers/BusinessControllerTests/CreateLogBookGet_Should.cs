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
    public class CreateLogBookGet_Should
    {
        [TestMethod]
        public async Task CallBusinessServiceOnce()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.CreateLogBook();

            businessServiceMocked.Verify(a => a.ListAllBusinessesAsync<BusinessDTO>(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var businessDTOs = new List<BusinessDTO> { new BusinessDTO() };
            var createLogBookViewModel = new CreateLogBookViewModel();

            businessServiceMocked.Setup(b => b.ListAllBusinessesAsync<BusinessDTO>())
                .ReturnsAsync(businessDTOs);

            mapperMocked.Setup(m => m.MapTo<CreateLogBookViewModel>(businessDTOs))
               .Returns(createLogBookViewModel);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            var result = await businessController.CreateLogBook() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(CreateLogBookViewModel));
        }
    }
}
