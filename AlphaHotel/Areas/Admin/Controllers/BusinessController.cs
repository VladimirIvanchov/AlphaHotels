using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IFacilityService facilityService;
        private readonly IPictureHelper pictureHelper;

        public BusinessController(IBusinessService businessService, IMappingProvider mapper, IFacilityService facilityService, IPictureHelper pictureHelper)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.facilityService = facilityService ?? throw new ArgumentNullException(nameof(facilityService));
            this.pictureHelper = pictureHelper ?? throw new ArgumentNullException(nameof(pictureHelper));
        }

        public async Task<IActionResult> AllBusiness()
        {
            var businesses = await this.businessService.ListAllBusinessesAsync<BusinessDTO>();

            return PartialView("_AllBusinessPartial", businesses);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBusiness()
        {
            var facilities = await this.facilityService.ListAllFacilitiesAsync();
            var vm = this.mapper.MapTo<CreateBusinessViewModel>(facilities);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBusiness(CreateBusinessViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var coverPicture = await this.pictureHelper.ConvertPicturePath(model.CoverPicture);
            var pictures = new List<string>();
            foreach (var picture in model.Pictures)
            {
                pictures.Add(await this.pictureHelper.ConvertPicturePath(picture));
            }

            var business = await this.businessService.CreateBusiness(model.Name, model.Location, model.About,
                                                      model.ShortDescription, coverPicture, pictures,
                                                      model.FacilitiesForTheBusiness);

            return RedirectToRoute(
                 new
                 {
                     controller = "Business",
                     action = "Details",
                     id = business.BusinessId
                 });
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

            await this.businessService.AddLogBookToBusinessAsync(model.LogBookName, model.BusinessId);
            return Json(model);
        }
    }
}