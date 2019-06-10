using AlphaHotel.Areas.Manager.Models;
using AlphaHotel.Areas.Manager.Utilities;
using AlphaHotel.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Areas.Manager.Hubs
{
    [Authorize(Roles = "Manager")]
    public class LogHub : Hub
    {
        private readonly ILogBookService logBookService;
        private readonly IAccountService accountService;
        private readonly static ConnectionMapping connections = new ConnectionMapping();

        public LogHub(ILogBookService logBookService, IAccountService accountService)
        {
            this.logBookService = logBookService ?? throw new ArgumentNullException(nameof(logBookService));
            this.accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        public async Task Send(LogViewModel model)
        {
            var log = await this.logBookService.FindLog(model.Id);
            var userNames = await this.accountService.CheckIfUserIsAllowedToSeeLogAsync(connections.GetConnections(), model.LogBookId);

            foreach (var connectionId in connections.GetConnections())
            {
                if (userNames.Contains(connectionId.Key))
                {
                    await this.Clients.Client(connectionId.Value).SendAsync("NewLog", log);
                }
            }
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            connections.Add(name, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.Identity.Name;

            connections.Remove(name);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
