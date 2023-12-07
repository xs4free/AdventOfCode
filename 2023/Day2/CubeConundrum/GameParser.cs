namespace CubeConundrum;

internal static class GameParser
{
    public static IEnumerable<Game> Parse(string[] lines)
    {
        var result = new List<Game>();
        
        foreach (var line in lines)
        {
            // line example: Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            int colonIndex = line.IndexOf(':');
            const int gameIdStart = 5; //skip "Game ";

            var gameIdText = line.Substring(gameIdStart, colonIndex - gameIdStart);
            var gameId = Convert.ToInt32(gameIdText);

            // 1 blue, 2 green
            // 3 green, 4 blue, 1 red
            // 1 green, 1 blue
            var drawsText = line.Substring(colonIndex + 1).Split(';');
            var draws = drawsText.Select(ParseDraw).ToList();
            
            result.Add(new Game(gameId, draws));
        }

        return result;
    }

    private static CubesDraw ParseDraw(string input)
    {
        var (blue, green, red) = ParseCubes(input);
        return new CubesDraw(blue, red, green);
    }
    
    /// <summary>
    /// Parse text like '1 blue, 2 green'
    /// </summary>
    public static BagContents ParseBagContents(string input)
    {
        var (blue, green, red) = ParseCubes(input);
        return new BagContents(blue, red, green);
    }

    private static (int blue, int green, int red) ParseCubes(string input)
    {
        // 1 blue
        // 2 green
        var cubesText = input.Split(',');

        int blue = 0, green = 0, red = 0;
                
        foreach (var cubeText in cubesText)
        {
            // 1 blue
            var split = cubeText.Trim().Split(' ');
            var cubeCount = Convert.ToInt32(split[0]);
            if (!Enum.TryParse<CubeColors>(split[1], true, out var cubeColor))
            {
                throw new InvalidDataException($"Unable to parse color from string '{split[1]}'");
            }

            switch (cubeColor)
            {
                case CubeColors.Red: 
                    red += cubeCount;
                    break;
                case CubeColors.Blue:
                    blue += cubeCount;
                    break;
                case CubeColors.Green:
                    green += cubeCount;
                    break;
            }
                    
        }

        return (blue, green, red);
    }
}