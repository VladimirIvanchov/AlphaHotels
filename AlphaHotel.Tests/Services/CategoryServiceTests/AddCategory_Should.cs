using AlphaHotel.Data;
using AlphaHotel.Services;
using AlphaHotel.Tests.TestUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace AlphaHotel.Tests.Services.CategoryServiceTests
{
    [TestClass]
    public class AddCategory_Should
    {
        [TestMethod]
        public async Task ThrowException_WhenCategoryAlreadyExists()
        {
            var categoryName = "category";

            CategoryTestUtils.GetContextWithCategory(nameof(ThrowException_WhenCategoryAlreadyExists), categoryName);

            using (var assertContext = new AlphaHotelDbContext(CategoryTestUtils.GetOptions(nameof(ThrowException_WhenCategoryAlreadyExists))))
            {
                var categoryService = new CategoryService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(
                    async () => await categoryService.AddCategory(categoryName));
            }
        }

        [TestMethod]
        public async Task AddCategory_Return_WhenAllParametersArePassed()
        {
            var categoryName = "category";

            //CategoryTestUtils.GetContextWithCategory(nameof(AddCategory_Return_WhenCategoryAllParametersArePassed), categoryName);

            using (var assertContext = new AlphaHotelDbContext(CategoryTestUtils.GetOptions(nameof(AddCategory_Return_WhenAllParametersArePassed))))
            {
                var categoryService = new CategoryService(assertContext);
                await categoryService.AddCategory(categoryName);

                var category = await assertContext.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);

                Assert.AreEqual(categoryName, category.Name);
            }
        }
    }
}
