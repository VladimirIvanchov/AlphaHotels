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
    }
}