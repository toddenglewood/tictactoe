using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using Ninject.Parameters;
using Ninject.Modules;
using Tictactoe.Domain;
using System.Reflection;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Conventions;

namespace Tictactoe.UI
{
    //static class Program
    //{
    //    /// <summary>
    //    /// The main entry point for the application.
    //    /// </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        var board = new Board(3, 3);
    //        var playerFactory = new PlayerFactory();
    //        var gameFactory = new GameFactory(board);

    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new Form1(gameFactory, playerFactory));
    //    }
    //}

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(new TictactoeModule()); // register

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = kernel.Get<Form1>(); // resolve

            Application.Run(mainForm);

            kernel.Dispose(); // release
        }
    }

    public class TictactoeModule : NinjectModule
    {
        public override void Load()
        {
            var assemblies = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(IGame)),
            };

            Kernel.Bind<Form1>().ToSelf();

            Kernel.Bind(t => t.From(assemblies)
                        .SelectAllClasses()
                        .Where(type => !type.Name.EndsWith("Factory"))
                        .BindAllInterfaces());

            Kernel.Bind(t => t.From(assemblies)
                        .SelectAllInterfaces()
                        .Where(type => type.Name.EndsWith("Factory"))
                        .BindToFactory());

            Kernel.Rebind<IBoard>().To<Board>()
                        .WithConstructorArgument("width", 3)
                        .WithConstructorArgument("height", 3);
        }
    }
}
