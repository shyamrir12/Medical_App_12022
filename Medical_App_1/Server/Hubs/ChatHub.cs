using Medical_App_1.Shared.Models;
using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical_App_1.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {

            //var users = new string[] { message.ToUserId, message.FromUserId };
            //await Clients.Users(users).SendAsync("ReceiveMessage", message);


            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public Task SendMessageToCaller(Message message)
        {
            return Clients.Caller.SendAsync("ReceiveMessage", message.FromUserId, message);
        }
    }
}
