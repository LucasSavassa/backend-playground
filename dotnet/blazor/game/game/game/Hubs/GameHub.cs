using Microsoft.AspNetCore.SignalR;

namespace game.Hubs
{
    public class GameHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            Console.WriteLine($"Player with ID '{Context.ConnectionId}' connected.");
        }
    }
}
