using System.Linq;

namespace Tictactoe.Domain
{
    public class Board : IBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IField[,] Fields { get; set; }
        public IFieldFactory FieldFactory { get; set; }
        public int WinnerId { get; set; }

        public Board(int width, int height, IFieldFactory fieldFactory)
        {
            Width = width;
            Height = height;
            FieldFactory = fieldFactory;
            Reset();
        }

        public void Reset()
        {
            Fields = new IField[Width, Height];

            for (int i = 0; i < Fields.GetLength(0); i++)
            {
                for (int j = 0; j < Fields.GetLength(1); j++)
                {
                    Fields[i, j] = FieldFactory.Create(i, j);
                }
            }
        }

        public bool IsMoveValid(int row, int column, int playerId)
        {
            // There will much more work to do in more complicated games
            if (Fields[row, column].PlayerId == 0) return true;
            return false;
        }

        public IMove InsertChip(int row, int column, int playerId)
        {
            bool success = false;
            bool gameOver = true;
            Fields[row, column].PlayerId = playerId;

            // Very bad, I know. But it's just quick temp solution:
            if (Fields[0, 0].PlayerId.Equals(playerId) && Fields[0, 1].PlayerId.Equals(playerId) && Fields[0, 2].PlayerId.Equals(playerId)) success = true;
            if (Fields[1, 0].PlayerId.Equals(playerId) && Fields[1, 1].PlayerId.Equals(playerId) && Fields[1, 2].PlayerId.Equals(playerId)) success = true;
            if (Fields[2, 0].PlayerId.Equals(playerId) && Fields[2, 1].PlayerId.Equals(playerId) && Fields[2, 2].PlayerId.Equals(playerId)) success = true;

            if (Fields[0, 0].PlayerId.Equals(playerId) && Fields[1, 0].PlayerId.Equals(playerId) && Fields[2, 0].PlayerId.Equals(playerId)) success = true;
            if (Fields[0, 1].PlayerId.Equals(playerId) && Fields[1, 1].PlayerId.Equals(playerId) && Fields[2, 1].PlayerId.Equals(playerId)) success = true;
            if (Fields[0, 2].PlayerId.Equals(playerId) && Fields[1, 2].PlayerId.Equals(playerId) && Fields[2, 2].PlayerId.Equals(playerId)) success = true;

            if (Fields[0, 0].PlayerId.Equals(playerId) && Fields[1, 1].PlayerId.Equals(playerId) && Fields[2, 2].PlayerId.Equals(playerId)) success = true;
            if (Fields[0, 2].PlayerId.Equals(playerId) && Fields[1, 1].PlayerId.Equals(playerId) && Fields[2, 0].PlayerId.Equals(playerId)) success = true;

            // Check if there any valid move has left
            if (Fields.Cast<IField>().Any(field => field.PlayerId == 0)) gameOver = false;
            
            return new Move(playerId, success, gameOver);
        }
    }
}