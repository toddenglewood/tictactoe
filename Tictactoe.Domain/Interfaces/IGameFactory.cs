namespace Tictactoe.Domain
{
    public interface IGameFactory
    {
        IGame CreateGame(GameType type, IBoard board);
    }
}