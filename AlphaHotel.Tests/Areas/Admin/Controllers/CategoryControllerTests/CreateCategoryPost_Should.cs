using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Admin.Controllers.CategoryControllerTests
{
    [TestClass]
    public class CreateCategoryPost_Should
    {
        [TestMethod]
        public async Task ReturnBadRequest_WhenModelIsInvalid()
        {
            var categoryServiceMocked = new Mock<ICategoryService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var createCategoryViewModel = new CreateCategoryViewModel();

            var categoryController = new CategoryController(categoryServiceMocked.Object,
                mapperMocked.Object);
            categoryController.ModelState.AddModelError("error", "error");

            var result = await categoryController.CreateCategory(createCategoryViewModel);

            Assert.AreEqual(result.GetType(), typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task CallCategoryServiceOnce()
        {
            var categoryName = "Ivan";
            var categoryServiceMocked = new Mock<ICategoryService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var createCategoryViewModel = new CreateCategoryViewModel
            {
                CategoryName = categoryName
            };

            var categoryController = new CategoryController(categoryServiceMocked.Object,
                mapperMocked.Object);

            await categoryController.CreateCategory(createCategoryViewModel);

            categoryServiceMocked.Verify(c => c.AddCategory(categoryName), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var categoryName = "Ivan";
            var categoryServiceMocked = new Mock<ICategoryService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var createCategoryViewModel = new CreateCategoryViewModel
            {
                CategoryName = categoryName
            };

            var categoryController = new CategoryController(categoryServiceMocked.Object,
                mapperMocked.Object);

            var result = await categoryController.CreateCategory(createCategoryViewModel);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}
