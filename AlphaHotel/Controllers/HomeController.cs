using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;

namespace AlphaHotel.Controllers
{
    public class HomeController : Controller
    {
        private const int numbersOfBusiness = 3;
        private readonly IBusinessService businessService;

        public HomeController(IBusinessService businessService)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
        }

        public async Task<IActionResult> Index()
        {
            var vm = await this.businessService.ListTopNBusinessesAsync(numbersOfBusiness);

            return View(vm);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
