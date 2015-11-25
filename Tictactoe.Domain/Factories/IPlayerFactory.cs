namespace Tictactoe.Domain
{
    public interface IPlayerFactory
    {
        IPlayer Create(PlayerType type, int id);
    }
}