using System.Collections.Generic;

namespace Tictactoe.Domain
{
    public interface IGameFactory
    {
        IBoard Board { get; set; }
        IGame Create(IEnumerable<IPlayer> players);
    }
}