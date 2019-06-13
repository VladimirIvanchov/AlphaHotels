using AlphaHotel.Areas.Admin.Controllers;
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
    public class BusinessLogbooksCreate_Should
    {
        [TestMethod]
        public async Task CallBusinessServiceOnce()
        {
            var id = 1;
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.BusinessLogbooksCreate(id);

            businessServiceMocked.Verify(a => a.ListBusinessLogbooksAsync(id), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var id = 1;
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var businessDTOs = new List<BusinessDTO> { new BusinessDTO() };

            businessServiceMocked.Setup(b => b.ListAllBusinessesAsync<BusinessDTO>())
                .ReturnsAsync(businessDTOs);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            var result = await businessController.BusinessLogbooksCreate(id) as PartialViewResult;

            Assert.AreEqual(result.ViewName, "_BusinessLogBooksCreatePartial");
        }
    }
}
