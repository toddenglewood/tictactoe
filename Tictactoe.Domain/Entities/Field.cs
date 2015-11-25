namespace Tictactoe.Domain
{
    public class Field : IField
    {
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Field(int row = 2, int column = 3)
        {
            Row = row;
            Column = column;
            PlayerId = 0;
        }
    }
}
