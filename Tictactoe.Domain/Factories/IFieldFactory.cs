namespace Tictactoe.Domain
{
    public interface IFieldFactory
    {
        IField Create(int row, int column);
    }
}
