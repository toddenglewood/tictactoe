using System.Collections.Generic;

namespace Tictactoe.Domain
{
    public class GameFactory : IGameFactory
    {
        private IPlayerFactory PlayerFactory { get; }

        public GameFactory(IPlayerFactory playerFactory)
        {
            PlayerFactory = playerFactory;
        }

        public IGame CreateGame(GameType type, IBoard board)
        {
            switch (type)
            {
                case GameType.SinglePlayer:
                    return new Game(type, board, new List<IPlayer> { CreateHuman(1), CreateBot(2) });
                case GameType.TwoPlayers:
                    return new Game(type, board, new List<IPlayer> { CreateHuman(1), CreateHuman(2) });
                case GameType.Online:
                    return new Game(type, board, new List<IPlayer> { CreateHuman(1), CreateOnlinePlayer(2) });
            }
            return null;
        }

        private IPlayer CreateBot(int id)
        {
            return PlayerFactory.CreatePlayer(PlayerType.Bot, id);
        }

        private IPlayer CreateHuman(int id)
        {
            return PlayerFactory.CreatePlayer(PlayerType.Human, id);
        }

        private IPlayer CreateOnlinePlayer(int id)
        {
            return PlayerFactory.CreatePlayer(PlayerType.OnlinePlayer, id);
        }
    }
}