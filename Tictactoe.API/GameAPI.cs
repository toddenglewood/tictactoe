using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tictactoe.Domain;

namespace TicTactoe.API
{
    public class GameAPI
    {
        public IGame CurrentGame { get; set; }

        public IGame CreateGame(IGameFactory gameFactory, GameType type, IBoard board)
        {
            CurrentGame = gameFactory.CreateGame(type, board);
            return CurrentGame;
        }

        public IMove MakeMove(int row, int column)
        {
            if (CurrentGame == null) return null;
            return CurrentGame.MakeMove(row, column);
        }

        //TODO: Online player move, or bot
    }
}
