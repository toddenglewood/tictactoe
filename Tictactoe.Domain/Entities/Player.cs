namespace Tictactoe.Domain
{
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PlayerType Type { get; set; }

        public Player(PlayerType type, int id)
        {
            Type = type;
            Id = id;
        }
    }
}