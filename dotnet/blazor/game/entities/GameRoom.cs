namespace entities
{
    public class GameRoom
    {
        public Guid ID { get; set; }
        public string Name { get; init; }

        public GameRoom(string name)
        {
            ID = Guid.NewGuid();
            Name = name;
        }
    }
}
