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
    
    [Fact]
    public void GetPositionsForEndlessLoop_Example()
    {
        var map = InputParser.Parse(_input);
        var positions = RouteCalculator.GetPositionsForEndlessLoop(map).ToList();

        Assert.Equal(6, positions.Count);
        Assert.Contains((3, 6), positions);
        Assert.Contains((6, 7), positions);
        Assert.Contains((7, 7), positions);
        Assert.Contains((1, 8), positions);
        Assert.Contains((3, 8), positions);
        Assert.Contains((7, 9), positions);
    }

    [Fact]
    public void GetPositionsForEndlessLoop_Edge_Case_2_Turns_Same_Spot()
    {
        string[] input = 
        [
            ".#...",
            ".....",
            "#...#",
            ".#^#."
        ];
        
        var map = InputParser.Parse(input);
        var positions = RouteCalculator.GetPositionsForEndlessLoop(map).ToList();

        Assert.Single(positions);
    }
    
}