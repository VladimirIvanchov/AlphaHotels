using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public BusinessController(IBusinessService businessService)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
        }

        public async Task<IActionResult> AllBusiness()
        {
            var businesses = await this.businessService.ListAllBusinessesAsync();

            return PartialView("_AllBusinessPartial", businesses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BusinessLogbooks(int id)
        {
            var logBooks = await this.businessService.ListBusinessLogbooksAsync(id);

            return PartialView("_BusinessLogBooksPartial", logBooks);
        }
    }
}