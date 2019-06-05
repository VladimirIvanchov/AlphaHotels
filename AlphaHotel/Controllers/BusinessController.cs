using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Controllers
{
    public class BusinessController : Controller
    {
        private const int pageSize = 9;
        private readonly IBusinessService businessService;

        public BusinessController(IBusinessService businessService)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
        }

        public async Task<IActionResult> Details(int id)
        {
            var vm = await this.businessService.FindDetaliedBusinessAsync(id);

            return View(vm);
        }

        public async Task<IActionResult> DetailsBusinessByName(string myHotel)
        {
            var vm = await this.businessService.FindDetaliedBusinessByNameAsync(myHotel);

            return View("Details", vm);
        }

        public async Task<IActionResult> ShowAllBusinesses(int? pageNumber)
        {
            var vm = await this.businessService.ListAllBusinessesByPageAsync(pageNumber, pageSize);

            return View(vm);
        }

        public async Task<IActionResult> FindBusiness([FromQuery(Name = "keyword")] string keyword)
        {
            var businesses = await this.businessService.ListAllBusinessesContainsKeyWordAsync(keyword ?? "".ToLower());

            return Json(businesses);
        }
    }
}