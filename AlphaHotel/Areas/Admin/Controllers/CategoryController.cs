using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Route("[area]/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IMappingProvider mapper;

        public CategoryController(ICategoryService categoryService, IMappingProvider mapper)
        {
            this.categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            var categories = await this.categoryService.ListAllCategoriesAsync();
            var vm = this.mapper.MapTo<CreateCategoryViewModel>(categories);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid parameters!");
                //return View(model);
            }

            try
            {
                await this.categoryService.AddCategory(model.CategoryName);

                return Json(model);
                //return RedirectToAction(nameof(CreateLogBook));
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }
        }
    }
}