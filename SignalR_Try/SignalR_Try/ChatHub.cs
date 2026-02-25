using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Try
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        [HubMethodName("sendMessage")]
        public void SendMessage(string name, string message)
        {
            // DBcode
            Clients.All.receiveMessage(name, message);
        }
    }
}