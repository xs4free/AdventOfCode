namespace Day14.Tests;

public class RobotSimulatorTests
{
    [Theory]
    [InlineData("p=2,4 v=2,-3", 0, 2, 4)]
    [InlineData("p=2,4 v=2,-3", 1, 4, 1)]
    [InlineData("p=2,4 v=2,-3", 2, 6, 5)]
    [InlineData("p=2,4 v=2,-3", 3, 8, 2)]
    [InlineData("p=2,4 v=2,-3", 4, 10, 6)]
    [InlineData("p=2,4 v=2,-3", 5, 1, 3)]
    public void Simulate_Part1_Example(string input, int seconds, int expectedX, int expectedY)
    {
        var mapSize = new MapSize(11, 7);
        string[] lines = [input];
        var robots = InputParser.Parse(lines);
        var newPosition = RobotSimulator.Simulate(robots.First(), seconds, mapSize);
        
        Assert.Equal(new Position(expectedX, expectedY), newPosition);
    }
}