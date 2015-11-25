using System.Collections.Generic;

namespace Tictactoe.Domain
{
    public class GameFactory : IGameFactory
    {
        public IBoard Board { get; set; }
        public GameFactory(IBoard board)
        {
            Board = board;
        }

        public IGame Create(IEnumerable<IPlayer> players)
        {
            return new Game(Board, players);
        }
    }
}