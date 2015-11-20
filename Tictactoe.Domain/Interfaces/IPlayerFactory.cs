namespace Tictactoe.Domain
{
    public interface IPlayerFactory
    {
        IPlayer CreatePlayer(PlayerType type, int id);
    }
}