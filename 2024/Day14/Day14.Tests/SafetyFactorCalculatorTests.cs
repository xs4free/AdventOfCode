namespace Day14.Tests;

public class SafetyFactorCalculatorTests
{
    [Fact]
    public void Calculate_Part1_Example()
    {
        var mapSize = new MapSize(11, 7);
        string[] lines = 
        [
            "p=0,4 v=3,-3",
            "p=6,3 v=-1,-3",
            "p=10,3 v=-1,2",
            "p=2,0 v=2,-1",
            "p=0,0 v=1,3",
            "p=3,0 v=-2,-2",
            "p=7,6 v=-1,-3",
            "p=3,0 v=-1,-2",
            "p=9,3 v=2,3",
            "p=7,3 v=-1,2",
            "p=2,4 v=2,-3",
            "p=9,5 v=-3,-3"
        ];
        var robots = InputParser.Parse(lines);
        var newPositions = robots.Select(robot => RobotSimulator.Simulate(robot, 100, mapSize)).ToList();
        
        var factor = SafetyFactorCalculator.Calculate(newPositions, mapSize); 
        
        Assert.Equal(12, factor);
    }
}