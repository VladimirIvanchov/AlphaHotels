using AlphaHotel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlphaHotel.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult PageNotFound()
        {
            return View("PageNotFound");
        }
    }
}