using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    [Route("[area]/[controller]/[action]")]
    public class BusinessController : Controller
    {
        private readonly IBusinessService businessService;
        private readonly IMappingProvider mapper;

        public BusinessController(IBusinessService businessService, IMappingProvider mapper)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> AllBusiness()
        {
            var businesses = await this.businessService.ListAllBusinessesAsync<BusinessDTO>();

            return PartialView("_AllBusinessPartial", businesses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BusinessLogbooks(int id)
        {
            var logBooks = await this.businessService.ListBusinessLogbooksAsync(id);

            return PartialView("_BusinessLogBooksPartial", logBooks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BusinessLogbooksCreate(int id)
        {
            var logBooks = await this.businessService.ListBusinessLogbooksAsync(id);

            return PartialView("_BusinessLogBooksCreatePartial", logBooks);
        }

        [HttpGet]
        public async Task<IActionResult> CreateLogBook()
        {
            var businesses = await this.businessService.ListAllBusinessesAsync<BusinessDTO>();
            var vm = this.mapper.MapTo<CreateLogBookViewModel>(businesses);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLogBook(CreateLogBookViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid parameters!");
            }

            try
            {
                await this.businessService.AddLogBookToBusinessAsync(model.LogBookName, model.BusinessId);

                return Json(model);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}