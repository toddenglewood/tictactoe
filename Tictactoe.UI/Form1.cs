using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tictactoe.Domain;
using TicTactoe.API;
using Tictactoe.DependencyResolver;
using Ninject;
using Ninject.Parameters;

namespace Tictactoe.UI
{
    public partial class Form1 : Form
    {   
        private  GameAPI GameAPI { get; } = new GameAPI();
        private  IGame CurrentGame { get; set; }
        IKernel kernel = new StandardKernel();

        public Form1()
        {
            InitializeComponent();

            // Load all dependencies
            var modules = new List<INinjectModule> { new TictactoeModule() };
            kernel.Load(modules);
        }

        private void buttonNewGameSingle_Click(object sender, EventArgs e)
        {
            StartNewGame(GameType.SinglePlayer);
        }

        private void buttonNewTwoPlayers_Click(object sender, EventArgs e)
        {
            StartNewGame(GameType.TwoPlayers);
        }

        private void buttonNewGameOnline_Click(object sender, EventArgs e)
        {
            StartNewGame(GameType.Online);
        }

        private void StartNewGame(GameType type)
        {
            EnableBoard(true);
            ResetBoard();

            // Without IoC
            //IPlayerFactory playerFactory = new PlayerFactory(); // Resolve player facotry
            //IGameFactory gameFactory = new GameFactory(playerFactory); // Resolve game facotry
            //IBoard board = new Board(3,3); // Resolve board

            // With IoC
            IPlayerFactory playerFactory = kernel.Get<IPlayerFactory>();
            IGameFactory gameFactory = kernel.Get<IGameFactory>(new ConstructorArgument("playerFactory", playerFactory));
            IBoard board = kernel.Get<IBoard>(new ConstructorArgument("width", 3), new ConstructorArgument("height", 3));

            CurrentGame = GameAPI.CreateGame(gameFactory, type, board);
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            if (clicked != null)
            {
                int[] xy;
                buttons.TryGetValue(clicked.Name, out xy);

                Console.WriteLine(clicked.Name + "[" + xy[0] + "," + xy[1] + "]");
                
                if (CurrentGame.IsMoveValid(xy[0], xy[1]))
                {
                    IMove result = CurrentGame.MakeMove(xy[0], xy[1]);
                    clicked.Text = result.PlayerId.ToString();
                    if (result.IsConnected)
                    {
                        EnableBoard(false);
                        MessageBox.Show("Finished! Player " + result.PlayerId + " won!");
                    }
                    else if (result.IsGameOver)
                    {
                        EnableBoard(false);
                        MessageBox.Show("Game over!!");
                    }
                }
            }
        }

        #region UI Helpers

        private Dictionary<string, int[]> buttons = new Dictionary<string, int[]>
        {
            { "button1", new[] {0, 0} },
            { "button2", new[] {0, 1} },
            { "button3", new[] {0, 2} },
            { "button4", new[] {1, 0} },
            { "button5", new[] {1, 1} },
            { "button6", new[] {1, 2} },
            { "button7", new[] {2, 0} },
            { "button8", new[] {2, 1} },
            { "button9", new[] {2, 2} }
        };

        private void EnableBoard(bool enable)
        {
            button1.Enabled = enable;
            button2.Enabled = enable;
            button3.Enabled = enable;
            button4.Enabled = enable;
            button5.Enabled = enable;
            button6.Enabled = enable;
            button7.Enabled = enable;
            button8.Enabled = enable;
            button9.Enabled = enable;
        }

        private void ResetBoard()
        {
            button1.Text = string.Empty;
            button2.Text = string.Empty;
            button3.Text = string.Empty;
            button4.Text = string.Empty;
            button5.Text = string.Empty;
            button6.Text = string.Empty;
            button7.Text = string.Empty;
            button8.Text = string.Empty;
            button9.Text = string.Empty;
        }

        #endregion


    }
}
