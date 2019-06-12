using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
using AlphaHotel.Models;
using AlphaHotel.Services;
using AlphaHotel.Services.Utilities;
using AlphaHotel.Tests.TestUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Services.BusinessServiceTests
{
    [TestClass]
    public class CreateBusiness_Should
    {
        [TestMethod]
        public async Task CreateBusiness_ThrowException_WhenLogBookAlreadyExists()
        {
            var businessName = "business";
            var location = "tsarigradsko";
            var about = "about";
            var shortDescription = "shortDescription";
            var coverPicture = "path";
            var pics =new List<string>(){ "path", "otherPath" };
            var facilities = new List<int>() { 1, 2 };
            var businessId = 1;

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            BusinessTestUtils.GetContextWithBusiness(nameof(CreateBusiness_ThrowException_WhenLogBookAlreadyExists), businessId, businessName);

            using (var assertContext = new AlphaHotelDbContext(CategoryTestUtils.GetOptions(nameof(CreateBusiness_ThrowException_WhenLogBookAlreadyExists))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await businessService.CreateBusiness(businessName, location, about, shortDescription, coverPicture, pics, facilities));
            }
        }

        [TestMethod]
        public async Task CreateBusiness_ReturnBusiness_WhenAllParametersArePassed()
        {
            var name = "business";
            var location = "tsarigradsko";
            var about = "about";
            var shortDescription = "shortDescription";
            var coverPicture = "path";
            var pics = new List<string>() { "path", "otherPath" };
            var facilities = new List<int>() { 1, 2 };

            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();
            var mappingProviderMocked = new Mock<IMappingProvider>();

            Business mapInput = null;
            mappingProviderMocked.Setup(mpm => mpm.MapTo<BusinessDTO>(It.IsAny<Business>()))
               .Callback<object>(inputArg => mapInput = inputArg as Business);

            var createdOn = dateTimeWrapperMocked.Object.Now();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(CreateBusiness_ReturnBusiness_WhenAllParametersArePassed))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                await businessService.CreateBusiness(name, location, about, shortDescription, coverPicture, pics, facilities);

                Assert.AreEqual(name, mapInput.Name);
                Assert.AreEqual(location, mapInput.Location);
                Assert.AreEqual(about, mapInput.About);
                Assert.AreEqual(shortDescription, mapInput.ShortDescription);
                Assert.AreEqual(coverPicture, mapInput.CoverPicture);
                Assert.AreEqual(pics.Count, mapInput.Pictures.Count);
                Assert.AreEqual(facilities.Count, mapInput.BusinessesFacilities.Count);
                Assert.AreEqual(createdOn, mapInput.CreatedOn);
            }
        }
    }
}
