using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Admin.Controllers.BusinessControllerTests
{
    [TestClass]
    public class CreateBusinessPost_Should
    {
        [TestMethod]
        public async Task ReturnCorrectViewModel_WhenModelIsInvalid()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var createBusinessViewModel = new CreateBusinessViewModel();

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);
            businessController.ModelState.AddModelError("error", "error");

            var result = await businessController.CreateBusiness(createBusinessViewModel) as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(CreateBusinessViewModel));
        }

        [TestMethod]
        public async Task CallConvertPicturePathForCoverPicture_WhenParameterIsValid()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var coverPictureMock = new Mock<IFormFile>();
            var pictureMock = new Mock<IFormFile>();
            var businessDTO = new BusinessDTO { BusinessId = 1 };

            var name = "Ivan";
            var location = "Tuk";
            var about = "ok";
            var shortDesc = "ok";
            var coverPicture = coverPictureMock.Object;
            var pictures = new List<IFormFile> { pictureMock.Object };
            var facilitiesForTheBusiness = new List<int> { 1 };

            var createBusinessViewModel = new CreateBusinessViewModel
            {
                Name = name,
                Location = location,
                About = about,
                ShortDescription = shortDesc,
                CoverPicture = coverPicture,
                Pictures = pictures,
                FacilitiesForTheBusiness = facilitiesForTheBusiness
            };

            businessServiceMocked.Setup(b => b.CreateBusiness(name, location, about, shortDesc, null, new List<string> { null }, facilitiesForTheBusiness))
                .ReturnsAsync(businessDTO);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.CreateBusiness(createBusinessViewModel);

            pictureHelper.Verify(p => p.ConvertPicturePath(coverPictureMock.Object), Times.Once);
        }

        [TestMethod]
        public async Task CallConvertPicturePathForPictures_WhenParameterIsValid()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var coverPictureMock = new Mock<IFormFile>();
            var pictureMock = new Mock<IFormFile>();
            var businessDTO = new BusinessDTO { BusinessId = 1 };

            var name = "Ivan";
            var location = "Tuk";
            var about = "ok";
            var shortDesc = "ok";
            var coverPicture = coverPictureMock.Object;
            var pictures = new List<IFormFile> { pictureMock.Object };
            var facilitiesForTheBusiness = new List<int> { 1 };

            var createBusinessViewModel = new CreateBusinessViewModel
            {
                Name = name,
                Location = location,
                About = about,
                ShortDescription = shortDesc,
                CoverPicture = coverPicture,
                Pictures = pictures,
                FacilitiesForTheBusiness = facilitiesForTheBusiness
            };

            businessServiceMocked.Setup(b => b.CreateBusiness(name, location, about, shortDesc, null, new List<string> { null }, facilitiesForTheBusiness))
                .ReturnsAsync(businessDTO);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.CreateBusiness(createBusinessViewModel);

            pictureHelper.Verify(p => p.ConvertPicturePath(pictureMock.Object), Times.Once);
        }

        [TestMethod]
        public async Task CallbusinessServiceOnce_WhenParameterIsValid()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var coverPictureMock = new Mock<IFormFile>();
            var pictureMock = new Mock<IFormFile>();
            var businessDTO = new BusinessDTO { BusinessId = 1 };

            var name = "Ivan";
            var location = "Tuk";
            var about = "ok";
            var shortDesc = "ok";
            var coverPicture = coverPictureMock.Object;
            var pictures = new List<IFormFile> { pictureMock.Object };
            var facilitiesForTheBusiness = new List<int> { 1 };

            var createBusinessViewModel = new CreateBusinessViewModel
            {
                Name = name,
                Location = location,
                About = about,
                ShortDescription = shortDesc,
                CoverPicture = coverPicture,
                Pictures = pictures,
                FacilitiesForTheBusiness = facilitiesForTheBusiness
            };

            businessServiceMocked.Setup(b => b.CreateBusiness(name, location, about, shortDesc, null, new List<string> { null }, facilitiesForTheBusiness))
                .ReturnsAsync(businessDTO);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            await businessController.CreateBusiness(createBusinessViewModel);

            businessServiceMocked.Verify(b => b.CreateBusiness(name, location, about, shortDesc, null, new List<string> { null }, facilitiesForTheBusiness), Times.Once);
        }

        [TestMethod]
        public async Task RedirectToRoute_WhenParameterIsValid()
        {
            var businessServiceMocked = new Mock<IBusinessService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var facilityServiceMocked = new Mock<IFacilityService>();
            var pictureHelper = new Mock<IPictureHelper>();
            var coverPictureMock = new Mock<IFormFile>();
            var pictureMock = new Mock<IFormFile>();
            var businessDTO = new BusinessDTO { BusinessId = 1 };

            var name = "Ivan";
            var location = "Tuk";
            var about = "ok";
            var shortDesc = "ok";
            var coverPicture = coverPictureMock.Object;
            var pictures = new List<IFormFile> { pictureMock.Object };
            var facilitiesForTheBusiness = new List<int> { 1 };

            var createBusinessViewModel = new CreateBusinessViewModel
            {
                Name = name,
                Location = location,
                About = about,
                ShortDescription = shortDesc,
                CoverPicture = coverPicture,
                Pictures = pictures,
                FacilitiesForTheBusiness = facilitiesForTheBusiness
            };

            businessServiceMocked.Setup(b => b.CreateBusiness(name, location, about, shortDesc, null, new List<string> { null }, facilitiesForTheBusiness))
                .ReturnsAsync(businessDTO);

            var businessController = new BusinessController(businessServiceMocked.Object,
                mapperMocked.Object, facilityServiceMocked.Object, pictureHelper.Object);

            var result = await businessController.CreateBusiness(createBusinessViewModel) as RedirectToRouteResult; ;
            var route = result.RouteValues.Values.ToList();

            Assert.AreEqual("Business", route[0]);
            Assert.AreEqual("Details", route[1]);
            Assert.AreEqual(1, route[2]);
        }
    }
}
