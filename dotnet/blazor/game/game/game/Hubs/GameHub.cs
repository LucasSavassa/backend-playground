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

        public async Task<GameRoom> CreateRoom(string roomName, string playerName)
        {
            GameRoom room = new(roomName);
            rooms.Add(room);

            Player player = new(Context.ConnectionId, playerName);
            room.TryAddPlayer(player);

            await Groups.AddToGroupAsync(Context.ConnectionId, $"{room.ID}");
            await Clients.All.SendAsync("Rooms", rooms.OrderBy(r => r.Name));

            return room;
        }

        public async Task<GameRoom?> JoinRoom(Guid id, string playerName)
        {
            GameRoom? room = rooms.FirstOrDefault(r => r.ID == id);

            if (room is null)
            {
                return null;
            }

            Player player = new(Context.ConnectionId, playerName);

            if (!room.TryAddPlayer(player))
            {
                return null;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, $"{room.ID}");
            await Clients.Group($"{room.ID}").SendAsync("PlayerJoined", player);

            return room;
        }
    }
}
