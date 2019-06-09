using AlphaHotel.Areas.Manager.Models;
using AlphaHotel.Common;
using AlphaHotel.DTOs;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Infrastructure.Wrappers.Contracts;
using AlphaHotel.Models;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlphaHotel.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize(Roles = "Manager")]
    [Route("[area]/[controller]/[action]")]
    public class LogBookController : Controller
    {
        private const int pageSize = 2;
        private readonly ILogBookService logBookService;
        private readonly IUserHelper userHelper;
        private readonly IMappingProvider mapper;
        private readonly IUserManagerWrapper<User> userManagerWrapper;

        public LogBookController(ILogBookService logBookService, IUserHelper userHelper, IMappingProvider mapper, IUserManagerWrapper<User> userManagerWrapper)
        {
            this.logBookService = logBookService ?? throw new ArgumentNullException(nameof(logBookService));
            this.userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.userManagerWrapper = userManagerWrapper ?? throw new ArgumentNullException(nameof(userManagerWrapper));
        }

        public async Task<IActionResult> AllLogbookLogs([FromQuery(Name = "keyword")] string keyword, int? pageNumber)
        {
            var managerId = this.userHelper.GetId(this.User);
            var logs = await this.logBookService.ListAllLogsForManagerAsync(managerId, pageNumber, pageSize, keyword ?? "".ToLower());

            return View(logs);
        }

        public async Task<IActionResult> FindLog([FromQuery(Name = "keyword")] string keyword, int? pageNumber)
        {
            var managerId = this.userHelper.GetId(this.User);
            var logs = await this.logBookService.ListAllLogsForManagerAsync(managerId, pageNumber, pageSize, keyword ?? "".ToLower());

            return PartialView("_LogsPartial", logs);
        }

        [HttpGet("{logId}")]
        public async Task<IActionResult> ShowStatusesOtherThanLogs(int logId)
        {
            var statuses = await this.logBookService.ListAllStatusesAsync();
            var vm = this.mapper.MapTo<StatusForLogViewModel>(statuses);
            vm.LogId = logId;

            return PartialView("_StatusesPartial", vm);
        }

        [HttpGet("{statusId}/{logId}")]
        public async Task<IActionResult> ChangeStatus(int statusId, int logId)
        {
            var status = await this.logBookService.ChangeStatusOfLogAsync(statusId, logId);

            return Json(status);
        }

        public async Task<IActionResult> FindLogAjax([FromQuery(Name = "keyword")] string keyword, int? pageNumber)
        {
            var managerId = this.userHelper.GetId(this.User);
            var logs = await this.logBookService.ListAllLogsForManagerAsync(managerId, pageNumber, pageSize, keyword ?? "".ToLower());

            return View("AllLogbookLogs", logs);
        }

        [HttpGet]
        public async Task<IActionResult> GetLogBooksAndCategories()
        {
            var userId = this.userHelper.GetId(User);
            var logbooksAndCategories = await this.logBookService.GetLogBooksAndCategories(userId);

            return PartialView("_DropdownPartial", logbooksAndCategories);
        }

        [HttpPost]
        public async Task<IActionResult> AddLog(AddLogViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest("Invalid parameters");
            }

            try
            {
                await this.logBookService.AddLog(model.LogBookId, model.UserId, model.Description, model.CategoryId);

                return Json(model);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError("Error", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ShowCategories()
        {
            var userId = this.userHelper.GetId(User);
            var categories = await this.logBookService.GetLogBooksAndCategories(userId);
            //var vm = this.mapper.MapTo<StatusForLogViewModel>(categories);

            return PartialView("_CategoriesPartial", categories);
        }

        [HttpGet]
        public async Task<IActionResult> ShowLogBooks()
        {
            var userId = this.userHelper.GetId(User);
            var logbooks = await this.logBookService.GetLogBooksAndCategories(userId);
            //var vm = this.mapper.MapTo<StatusForLogViewModel>(categories);

            return PartialView("_LogBookPartial", logbooks);
        }

        //var model = new MySensorsViewModel
        //{
        //    MeasureTypes = new SelectList(ItemsInCollection, "dataValueField", "dataTextField"),

        //};
    }
}