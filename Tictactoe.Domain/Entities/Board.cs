using System.Linq;

namespace Tictactoe.Domain
{
    public class Board : IBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Fields { get; set; }
        public int WinnerId { get; set; }

        public Board(int width, int heigh)
        {
            Width = width;
            Height = heigh;
            Reset();
        }

        public void Reset()
        {
            Fields = new int[Width,Height];
            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = 0;
                }
            }
        }

        public bool IsMoveValid(int row, int column, int playerId)
        {
            // There will much more work to do in more complicated games
            if (Fields[row, column] == 0) return true;
            return false;
        }

        public IMove InsertChip(int row, int column, int playerId)
        {
            bool success = false;
            bool gameOver = true;
            Fields[row, column] = playerId;

            // Very bad, I know. But it's just quick temp solution:
            if (Fields[0, 0].Equals(playerId) && Fields[0, 1].Equals(playerId) && Fields[0, 2].Equals(playerId)) success = true;
            if (Fields[1, 0].Equals(playerId) && Fields[1, 1].Equals(playerId) && Fields[1, 2].Equals(playerId)) success = true;
            if (Fields[2, 0].Equals(playerId) && Fields[2, 1].Equals(playerId) && Fields[2, 2].Equals(playerId)) success = true;

            if (Fields[0, 0].Equals(playerId) && Fields[1, 0].Equals(playerId) && Fields[2, 0].Equals(playerId)) success = true;
            if (Fields[0, 1].Equals(playerId) && Fields[1, 1].Equals(playerId) && Fields[2, 1].Equals(playerId)) success = true;
            if (Fields[0, 2].Equals(playerId) && Fields[1, 2].Equals(playerId) && Fields[2, 2].Equals(playerId)) success = true;

            if (Fields[0, 0].Equals(playerId) && Fields[1, 1].Equals(playerId) && Fields[2, 2].Equals(playerId)) success = true;
            if (Fields[0, 2].Equals(playerId) && Fields[1, 1].Equals(playerId) && Fields[2, 0].Equals(playerId)) success = true;

            // Check if there any valid move has left
            if (Fields.Cast<int>().Any(field => field == 0)) gameOver = false;
            
            return new Move(playerId, success, gameOver);
        }
    }
}