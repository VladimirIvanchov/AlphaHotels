using System;
using System.Threading.Tasks;
using AlphaHotel.Areas.Manager.Models;
using AlphaHotel.Common;
using AlphaHotel.Infrastructure.MappingProviders;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public LogBookController(ILogBookService logBookService, IUserHelper userHelper, IMappingProvider mapper)
        {
            this.logBookService = logBookService ?? throw new ArgumentNullException(nameof(logBookService));
            this.userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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
    }
}