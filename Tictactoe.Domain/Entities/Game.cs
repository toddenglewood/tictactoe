using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe.Domain
{
    public class Game : IGame
    {
        private int currentPlayerIndex = 1;

        public Game(GameType type, IBoard board, List<IPlayer> players)
        {
            Type = type;
            Board = board;
            Players = players;
        }

        public GameType Type { get; }
        public IBoard Board { get; }
        public List<IPlayer> Players { get; }

        public bool IsMoveValid(int row, int column)
        {
            // It could be done entierly here. Just doing what Board now is doing: if (Board.Fields[row, column] == 0) return true; 
            // But there can be much more things to do in more complicated games, so I'm not sure about that
            // I left that job in Board class, and just call it.

            if (Players[currentPlayerIndex - 1].Type.Equals(PlayerType.Human))
            {
                return Board.IsMoveValid(row, column, currentPlayerIndex);
            }

            //if current player is Bot or Online player, your move is not allowed
            return false;
        }

        public IMove MakeMove(int row, int column)
        {
            IMove result = Board.InsertChip(row, column, currentPlayerIndex);

            // Set next player
            if (!result.IsConnected) currentPlayerIndex = currentPlayerIndex == 1 ? 2 : 1;

            return result;
        }
    }
}
