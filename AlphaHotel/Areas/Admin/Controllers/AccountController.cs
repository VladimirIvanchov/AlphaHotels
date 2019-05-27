using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Areas.Admin.Models;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Models.Common;
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
        private readonly IBusinessService businessService;
        private readonly IMappingProvider mapper;

        public AccountController(IAccountService accountService, IBusinessService businessService, IMappingProvider mapper)
        {
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            this.businessService = businessService ?? throw new ArgumentNullException(nameof(businessService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> AllAcounts()
        {
            var accounts = await this.accountService.ListAllUsersAsync();

            return View(accounts);
        }

        [HttpGet]
        public async Task<IActionResult> EditAccount(string accountId)
        {
            var account = await this.accountService.FindAccountAsync(accountId);

            if (account.Role == UserRoleTypes.Manager.ToString())
            {
                var logbooks = await this.businessService.ListBusinessLogbooksAsync(account.BusinessId ?? 0);

                var vm = this.mapper.MapTo<AccountViewModel>(account);
                vm.LogBooks = logbooks;

                return View(vm);
            }

            var vmNotManager = this.mapper.MapTo<AccountViewModel>(account);
            return View(vmNotManager);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(AccountViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await this.accountService.EditAccountAsync(model.Id, model.UserName, model.Email, model.IsDeleted, model.LogBookId);

                return RedirectToRoute(
                    new
                    {
                        area = "Admin",
                        controller = "Account",
                        action = "AllAcounts"
                    });
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }
        }
    }
}