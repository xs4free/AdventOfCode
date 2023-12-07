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

    public static int GetPowerOfFewestPossibleCubes(string[] games)
    {
        var parsedGames = GameParser.Parse(games);
        
        var fewestPossibleBags = parsedGames.Select(GetFewestPossibleCubes);
        
        return fewestPossibleBags.Select(bag => bag.Power).Sum();
    }

    private static BagContents GetFewestPossibleCubes(Game game)
    {
        int red = 0, green = 0, blue = 0;

        foreach (var draw in game.Draws)
        {
            red = Math.Max(red, draw.Red);
            green = Math.Max(green, draw.Green);
            blue = Math.Max(blue, draw.Blue);
        }

        return new BagContents(blue, red, green);
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