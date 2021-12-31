namespace Day4_Giant_Squid
{
    public class GameAnalyzer
    {
        public Board? GetWinningBoard(Game game)
        {
            return game.Boards.FirstOrDefault();
        }
    }
}
