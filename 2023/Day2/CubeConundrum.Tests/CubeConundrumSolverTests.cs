namespace CubeConundrum.Tests;

public class CubeConundrumSolverTests
{
    [Fact]
    public void GetSumOfPossibleGameIds_Example()
    {
        var bagContents = "12 red, 13 green, 14 blue";
        var games = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };
       
        Assert.Equal(8, CubeConundrumSolver.GetSumOfPossibleGameIds(bagContents, games));
    }

    [Fact]
    public void GetPowerOfFewestPossibleCubes_Example()
    {
        var games = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };
       
        Assert.Equal(2286, CubeConundrumSolver.GetPowerOfFewestPossibleCubes(games));
    }
}