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
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public async Task<IActionResult> AllAcounts()
        {
            var accounts = await this.accountService.ListAllUsersAsync();

            return View(accounts);
        }

        public async Task<IActionResult> Details()
        {

            return View();
        }

        public async Task<IActionResult> Delete()
        {

            return View();
        }
    }
}