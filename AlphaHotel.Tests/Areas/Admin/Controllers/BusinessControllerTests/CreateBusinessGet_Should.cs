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
    public class CreateBusinessGet_Should
    {
        [TestMethod]
        public async Task CallFacilityServiceOnce()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.CreateBusiness();

            facilityServiceMocked.Verify(f => f.ListAllFacilitiesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var facilityDTOs = new List<FacilityDTO> { new FacilityDTO() };
            var createBusinessVM = new CreateBusinessViewModel();

            facilityServiceMocked.Setup(f => f.ListAllFacilitiesAsync())
                .ReturnsAsync(facilityDTOs);

            mapperMocked.Setup(m => m.MapTo<CreateBusinessViewModel>(facilityDTOs))
                .Returns(createBusinessVM);

            var accountController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            var result = await accountController.CreateBusiness() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(CreateBusinessViewModel));
        }
    }
}
