using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tictactoe.Domain;

namespace Tictactoe.DependencyResolver
{
    public class TictactoeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPlayerFactory>().To<PlayerFactory>();
            Bind<IGameFactory>().To<GameFactory>();
            Bind<IBoard>().To<Board>();
        }
    }
}
