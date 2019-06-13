using AlphaHotel.Areas.Admin.Controllers;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Tests.Areas.Admin.Controllers.CategoryControllerTests
{
    [TestClass]
    public class CreateCategoryGet_Should
    {
        [TestMethod]
        public async Task CallCategoryServiceOnce()
        {
            var categoryServiceMocked = new Mock<ICategoryService>();
            var mapperMocked = new Mock<IMappingProvider>();

            var categoryController = new CategoryController(categoryServiceMocked.Object,
                mapperMocked.Object);

            await categoryController.CreateCategory();

            categoryServiceMocked.Verify(c => c.ListAllCategoriesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task ReturnCorrectViewModel()
        {
            var categoryServiceMocked = new Mock<ICategoryService>();
            var mapperMocked = new Mock<IMappingProvider>();
            var createCategoryViewModel = new CreateCategoryViewModel();
            var categoryDTOs = new List<CategoryDTO> { new CategoryDTO() };

            categoryServiceMocked.Setup(c => c.ListAllCategoriesAsync())
               .ReturnsAsync(categoryDTOs);

            mapperMocked.Setup(m => m.MapTo<CreateCategoryViewModel>(categoryDTOs))
                .Returns(createCategoryViewModel);

            var categoryController = new CategoryController(categoryServiceMocked.Object,
                mapperMocked.Object);

            var result = await categoryController.CreateCategory() as ViewResult;

            Assert.IsInstanceOfType(result.Model, typeof(CreateCategoryViewModel));
        }
    }
}
