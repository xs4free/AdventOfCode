namespace CubeConundrum;

public static class CubeConundrumSolver
{
    public static int GetSumOfPossibleGameIds(string bagContents, string[] games)
    {
        var bag = GameParser.ParseBagContents(bagContents);
        var parsedGames = GameParser.Parse(games);
        
        var possibleGames = GetPossibleGames(bag, parsedGames);
        
        return possibleGames.Select(game => game.Id).Sum();
    }
    
    private static IEnumerable<Game> GetPossibleGames(BagContents bagContents, IEnumerable<Game> games)
    {
        return games.Where(game => IsGamePossibleWithBag(bagContents, game)).ToList();
    }

    private static bool IsGamePossibleWithBag(BagContents bag, Game game)
    {
        return game.Draws.All(draw => IsDrawPossibleWithBag(bag, draw));
    }

    private static bool IsDrawPossibleWithBag(BagContents bag, CubesDraw draw)
    {
        return draw.Red <= bag.Red && draw.Green <= bag.Green && draw.Blue <= bag.Blue;
    }
}