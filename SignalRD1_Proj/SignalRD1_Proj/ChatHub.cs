using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRD1_Proj
{
    // The HubName attribute specifies the name of the hub that clients will use to connect to it. If you don't specify a name, the class name will be used by default.
    [HubName("chat")]
    public class ChatHub : Hub
    {
        [HubMethodName("sendMessage")] // The HubMethodName attribute specifies the name of the method that clients will call to invoke this method. If you don't specify a name, the method name will be used by default.
        public void SendMessage(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            // All: Update all clients that are connected to the hub instead of just the caller.
            // sendMessage: The name of the method to call on the client. This method must be defined in the client code.
            Clients.All.newMessage(name, message);
        }
        // let us imagine that we have class called message with properties name and Text, then we can change the method signature to accept an object of type message instead of two separate parameters. This can make the code cleaner and easier to maintain.
        //[HubMethodName("sendMessage")]
        //public void SendMessage(Message message)
        //{
        //    Clients.All.newMessage(message.Name, message.Text);
        //}
        // in the client code, we would need to create an object of type message and pass it to the sendMessage method instead of passing two separate parameters.
        // the change in the client code would look something like this:
        // prox.on('newMessage', function (message) {
        //$("ul").append("<li><strong>" + message.Name + "</strong>: " + message.Text + "</li>");
        // });
        // calling server method:
        // prox.invoke('sendMessage', { Name: name, Text: $("#txt").val() })
    }
}