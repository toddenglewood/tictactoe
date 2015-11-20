namespace Tictactoe.Domain
{
    public interface IMove
    {
        int PlayerId { get; set; }
        bool IsConnected { get; }
        bool IsGameOver { get; }
    }
}