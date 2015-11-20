namespace Tictactoe.Domain
{
    public interface IPlayer
    {
        int Id { get; set; }
        string Name { get; set; }
        PlayerType Type { get; set; }
    }
}