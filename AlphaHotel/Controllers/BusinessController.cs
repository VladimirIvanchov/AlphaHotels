using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AlphaHotel.Controllers
{
    public class BusinessController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}