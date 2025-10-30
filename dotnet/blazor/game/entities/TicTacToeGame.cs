
namespace entities
{
    public class TicTacToeGame
    {
        public string? PlayerWhiteId { get; set; }
        public string? PlayerBlackId { get; set; }
        public string? CurrentPlayerId { get; set; }
        public string? CurrentPlayerSymbol => CurrentPlayerId == PlayerWhiteId ? "X" : "O";
        public bool Started { get; set; }
        public bool Finished { get; set; }
        public bool IsDraw { get; set; }
        public string? Winner { get; set; }
        public List<List<string>> Board { get; set; } = new List<List<string>>(3);

        public void Start()
        {
            CurrentPlayerId = PlayerWhiteId;
            Started = true;
            Finished = false;
            Winner = null;
            IsDraw = false;

            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Board.Clear();

            for (int i = 0; i < 3; i++)
            {
                Board.Add(new List<string> { "", "", "" });
            }
        }
    }
}
