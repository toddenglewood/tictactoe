namespace Tictactoe.Domain
{
    public interface IField
    {
        int PlayerId { get; set; }
        int Row { get; set; }
        int Column { get; set; }
    }
}
