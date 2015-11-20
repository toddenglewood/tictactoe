namespace Tictactoe.Domain
{
    // Separate class for Move result, because in more compilcated games, 
    // there could be more info to pass.
    // Even here, UI would like to know how fields are connected (when won) - to show it (painting the line or sth)
    public class Move : IMove
    {
        public int PlayerId { get; set; }
        public bool IsConnected { get; }
        public bool IsGameOver { get; }

        public Move(int playerId, bool isConnected, bool isGameOver = false)
        {
            PlayerId = playerId;
            IsConnected = isConnected;
            IsGameOver = isGameOver;
        }
    }
}