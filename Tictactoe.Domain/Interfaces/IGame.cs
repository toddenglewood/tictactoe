using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictactoe.Domain
{
    public interface IGame
    {
        IBoard Board { get; }
        List<IPlayer> Players { get; }

        bool IsMoveValid(int row, int column);
        IMove MakeMove(int row, int column);
    }
}
