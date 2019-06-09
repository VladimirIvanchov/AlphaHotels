using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using Microsoft.Extensions.Caching.Memory;

namespace AlphaHotel.Controllers
{
    public class HomeController : Controller
    {
        private const int numbersOfBusiness = 3;
        private readonly IBusinessService businessService;
        private readonly IMemoryCache memoryCache;

        public HomeController(IBusinessService businessService, IMemoryCache memoryCache)
        {
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
            this.memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task<IActionResult> Index()
        {
            var cachedBusiness = await memoryCache.GetOrCreateAsync("GetBusiness", async entry =>
            {
                entry.AbsoluteExpiration = DateTime.UtcNow.AddHours(2);
                return await this.businessService.ListTopNBusinessesAsync(numbersOfBusiness);
            });

            return View(cachedBusiness);
        }
    }
}
