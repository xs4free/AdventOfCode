namespace Day01.Tests;

public class DistanceCalculatorTests
{
    [Fact]
    public void Example()
    {
        string[] input = [ "3   4", "4   3", "2   5", "1   3", "3   9", "3   3" ];

        var (l1, l2) = InputParser.Parse(input);
        
        var actual = DistanceCalculator.Calculate(l1, l2);
        
        Assert.Equal(11, actual);
    }
}