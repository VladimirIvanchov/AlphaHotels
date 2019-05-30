using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaHotel.Common;
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
        private readonly ILogBookService logBookService;
        private readonly IUserHelper userHelper;

        public LogBookController(ILogBookService logBookService, IUserHelper userHelper)
        {
            this.logBookService = logBookService ?? throw new ArgumentNullException(nameof(logBookService));
            this.userHelper = userHelper ?? throw new ArgumentNullException(nameof(userHelper));
        }
        public async Task<IActionResult> AllLogbookLogs()
        {
            var userId = this.userHelper.GetId(this.User);
            var logs = await this.logBookService.ListAllLogsForManagerAsync(userId);

            return View(logs);
        }
    }
}