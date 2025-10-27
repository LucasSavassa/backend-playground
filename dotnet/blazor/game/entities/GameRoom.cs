namespace entities
{
    public class GameRoom
    {
        public Guid ID { get; set; }
        public string Name { get; init; }
        public List<Player> Players { get; set; } = [];
        public TicTacToeGame Game { get; set; } = new();

        public GameRoom(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }

        public bool TryAddPlayer(Player player)
        {
            if (Players.Count > 1)
            {
                return false;
            }

            if (Players.Any(x => x.ConnectionId == player.ConnectionId))
            {
                return false;
            }

            Players.Add(player);

            if (Players.Count == 1)
            {
                Game.PlayerWhiteId = player.ConnectionId;
            }
            else if (Players.Count == 2)
            {
                Game.PlayerBlackId = player.ConnectionId;
            }

            return true;
        }
    }
}
