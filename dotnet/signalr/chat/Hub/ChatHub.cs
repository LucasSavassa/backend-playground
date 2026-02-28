using Microsoft.AspNetCore.SignalR;

namespace chat
{
    public class ChatHub : Hub
    {
        public Task Broadcast(string name, string message)
        {
            return Clients.All.SendAsync("broadcast", name, message);
        }

        public Task Echo(string name, string message)
        {
            return Clients.Client(Context.ConnectionId).SendAsync("echo", name, message);
        }
    }
}
