using Ninject.Extensions.Factory;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tictactoe.Domain;
using Ninject.Extensions.Conventions;

namespace Tictactoe.DependencyResolver
{
    public class TictactoeModule : NinjectModule
    {
        public override void Load()
        {
            var assemblies = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(IGame)),
            };

            //Kernel.Bind<Form1>().ToSelf();

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
