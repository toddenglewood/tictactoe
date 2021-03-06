﻿namespace Tictactoe.Domain
{
    public interface IBoard
    {
        int Width { get; set; }
        int Height { get; set; }
        IField[,] Fields { get; set; }
        IFieldFactory FieldFactory { get; set; }
        int WinnerId { get; set; }

        void Reset();
        bool IsMoveValid(int row, int column, int playerId);
        IMove InsertChip(int row, int column, int playerId);
    }
}