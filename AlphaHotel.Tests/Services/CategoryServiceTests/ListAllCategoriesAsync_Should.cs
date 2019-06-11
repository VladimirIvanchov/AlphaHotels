using AlphaHotel.Data;
using AlphaHotel.Services;
using AlphaHotel.Tests.TestUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Services.CategoryServiceTests
{
    [TestClass]
    public class ListAllCategoriesAsync_Should
    {
        [TestMethod]
        public async Task ListAllCategoriesAsync_ReturnCategories()
        {
            var categoryId = 1;

            CategoryTestUtils.ResetAutoMapper();
            CategoryTestUtils.InitializeAutoMapper();
            CategoryTestUtils.GetContextWithCategories(nameof(ListAllCategoriesAsync_ReturnCategories), categoryId);

            using (var assertContext = new AlphaHotelDbContext(CategoryTestUtils.GetOptions(nameof(ListAllCategoriesAsync_ReturnCategories))))
            {
                var categoryService = new CategoryService(assertContext);
                var categories = await categoryService.ListAllCategoriesAsync();

                Assert.AreEqual(1, categories.Count);
            }
        }
    }
}
