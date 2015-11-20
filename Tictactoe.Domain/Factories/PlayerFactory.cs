namespace Tictactoe.Domain
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(PlayerType type, int id)
        {
            return new Player(type, id);
        }
    }
}