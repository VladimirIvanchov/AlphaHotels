using AlphaHotel.Data;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.PagingProvider;
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

            var mappingProviderMocked = new Mock<IMappingProvider>();
            var dateTimeWrapperMocked = new Mock<IDateTimeWrapper>();
            var paginatedListMocked = new Mock<IPaginatedList<BusinessShortInfoDTO>>();

            var createdOn = dateTimeWrapperMocked.Object.Now();

            BusinessTestUtils.ResetAutoMapper();
            BusinessTestUtils.InitializeAutoMapper();
            //BusinessTestUtils.GetContextWithFullBusiness(nameof(CreateBusiness_ReturnBusiness_WhenAllParametersArePassed), name, location, about, shortDescription, coverPicture);

            using (var assertContext = new AlphaHotelDbContext(BusinessTestUtils.GetOptions(nameof(CreateBusiness_ReturnBusiness_WhenAllParametersArePassed))))
            {
                var businessService = new BusinessService(assertContext, mappingProviderMocked.Object, dateTimeWrapperMocked.Object, paginatedListMocked.Object);
                var businessDto = await businessService.CreateBusiness(name, location, about, shortDescription, coverPicture, pics, facilities);

                var business = await assertContext.Businesses.FirstOrDefaultAsync(b => b.Name == name);

                Assert.AreEqual(name, business.Name);
                Assert.AreEqual(location, business.Location);
                Assert.AreEqual(about, business.About);
                Assert.AreEqual(shortDescription, business.ShortDescription);
                Assert.AreEqual(coverPicture, business.CoverPicture);
                Assert.AreEqual(pics.Count, business.Pictures.Count);
                Assert.AreEqual(facilities.Count, business.BusinessesFacilities.Count);
                Assert.AreEqual(createdOn, business.CreatedOn);

                //Assert.AreEqual(name, businessDto.Name);

            }
        }
    }
}
