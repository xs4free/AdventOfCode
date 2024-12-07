namespace Day06.Tests;

public class RouteCalculatorTests
{
    private readonly string[] _input = 
    [
        "....#.....",
        ".........#",
        "..........",
        "..#.......",
        ".......#..",
        "..........",
        ".#..^.....",
        "........#.",
        "#.........",
        "......#..."
    ];
    
    [Fact]
    public void CountStepsFromStartToExit_Example()
    {
        var map = InputParser.Parse(_input);
        var steps = RouteCalculator.CountStepsFromStartToExit(map);

        Assert.Equal(41, steps);
    }
}