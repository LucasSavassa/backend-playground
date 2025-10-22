using entities;
using Microsoft.AspNetCore.SignalR;

namespace game.Hubs
{
    public class GameHub : Hub
    {
        private static readonly List<GameRoom> rooms = new();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            await Clients.Caller.SendAsync("Rooms", rooms.OrderBy(r => r.Name));

            Console.WriteLine($"Player with ID '{Context.ConnectionId}' connected.");
        }

        public async Task<GameRoom> CreateRoom(string playerName, string roomName)
        {
            GameRoom room = new(roomName);
            rooms.Add(room);
            await Clients.All.SendAsync("Rooms", rooms.OrderBy(r => r.Name));
            return room;
        }
    }
}
