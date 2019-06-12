using AlphaHotel.Data;
using AlphaHotel.Services;
using AlphaHotel.Tests.TestUtils;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Services.FacilityServiceTests
{
    [TestClass]
    public class ListAllFacilitiesAsync_Should
    {
        [TestMethod]
        public async Task ReturnAllFacilities()
        {
            var facilityId = 1;
            FacilityTestUtils.ResetAutoMapper();
            FacilityTestUtils.InitializeAutoMapper();
            FacilityTestUtils.GetContextWithFacilities(nameof(ReturnAllFacilities), facilityId);

            using (var assertContext = new AlphaHotelDbContext(FacilityTestUtils.GetOptions(nameof(ReturnAllFacilities))))
            {
                var facilityService = new FacilityService(assertContext);
                var facilities = await facilityService.ListAllFacilitiesAsync();

                Assert.AreEqual(1, facilities.Count);
            }
        }
    }
}
