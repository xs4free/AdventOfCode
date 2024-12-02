namespace Day02.Tests;

public class SafetyEvaluatorTests
{
    [Fact]
    public void Example_Without_Dampening()
    {
        string[] input = ["7 6 4 2 1","1 2 7 8 9","9 7 6 2 1","1 3 2 4 5","8 6 4 4 1","1 3 6 7 9"];
        
        var reports = InputParser.Parse(input);
        var safeReports = reports.Count(report => SafetyEvaluator.IsSafe(report, useDampening: false));

        Assert.Equal(2, safeReports);
    }

    [Fact]
    public void Example_With_Dampening()
    {
        string[] input = ["1 8 2 4 5"];
        
        var reports = InputParser.Parse(input);
        var reportIsSafe = SafetyEvaluator.IsSafe(reports.First(), useDampening:true);

        Assert.True(reportIsSafe);
    }

    [Theory]
    [InlineData("7 6 4 2 1", true)] //Safe without removing any level.
    [InlineData("1 2 7 8 9", false)] //Unsafe regardless of which level is removed.
    [InlineData("9 7 6 2 1", false)] //Unsafe regardless of which level is removed.
    [InlineData("4 4 4 7 8", false)] //Unsafe regardless of which level is removed.
    [InlineData("8 6 6 6 4", false)] //Unsafe regardless of which level is removed.
    [InlineData("1 3 6 6 6", false)] //Unsafe regardless of which level is removed.

    [InlineData("4 0 6 7 8", true)] //Safe by removing the second level, 0.
    [InlineData("4 1 6 7 8", true)] //Safe by removing the second level, 1.
    [InlineData("4 4 6 7 8", true)] //Safe by removing the second level, 4.
    [InlineData("4 6 6 7 8", true)] //Safe by removing the second level, 6.
    [InlineData("4 8 6 7 8", true)] //Safe by removing the second level, 8.
    
    [InlineData("8 6 2 4 1", true)] //Safe by removing the third level, 2.
    [InlineData("8 6 4 4 1", true)] //Safe by removing the third level, 4.
    [InlineData("8 6 6 4 1", true)] //Safe by removing the third level, 6.
    [InlineData("8 6 8 4 1", true)] //Safe by removing the third level, 8.
    [InlineData("8 6 10 4 1", true)] //Safe by removing the third level, 10.

    [InlineData("8 6 5 40 3", true)] //Safe by removing the fourth level, 2.
    [InlineData("8 6 5 6 3", true)] //Safe by removing the fourth level, 4.
    [InlineData("8 6 5 5 3", true)] //Safe by removing the fourth level, 6.
    [InlineData("8 6 5 0 3", true)] //Safe by removing the fourth level, 8.
    [InlineData("8 6 5 3 3", true)] //Safe by removing the fourth level, 10.
    
    [InlineData("0 4 6 7 9", true)] //Safe by removing the first level.
    [InlineData("10 4 6 7 9", true)] //Safe by removing the first level.
    [InlineData("4 4 6 7 9", true)] //Safe by removing the first level.
    [InlineData("5 4 6 7 9", true)] //Safe by removing the first level.
    
    [InlineData("1 3 6 7 19", true)] //Safe by removing the last level.
    [InlineData("1 3 6 7 7", true)] //Safe by removing the last level.
    [InlineData("1 3 6 7 6", true)] //Safe by removing the last level.
    [InlineData("1 3 6 7 1", true)] //Safe by removing the last level.
    
    [InlineData("48 46 47 49 51 54 56", true)] //Safe by removing the last level.
    [InlineData("1 1 2 3 4 5", true)] //Safe by removing the last level.
    [InlineData("1 2 3 4 5 5", true)] //Safe by removing the last level.
    [InlineData("5 1 2 3 4 5", true)] //Safe by removing the last level.
    [InlineData("1 4 3 2 1", true)] //Safe by removing the last level.
    [InlineData("1 6 7 8 9", true)] //Safe by removing the last level.
    [InlineData("1 2 3 4 3", true)] //Safe by removing the last level.
    [InlineData("9 8 7 6 7", true)] //Safe by removing the last level.
    [InlineData("7 10 8 10 11", true)] //Safe by removing the last level.
    [InlineData("29 28 27 25 26 25 22 20", true)] //Safe by removing the last level.
    
    public void All_Cases_With_Dampening(string input, bool expectedResult)
    {
        string[] inputAsArray = { input };
        var reports = InputParser.Parse(inputAsArray);
        var reportIsSafe = SafetyEvaluator.IsSafe(reports.First(), useDampening: true);

        Assert.Equal(expectedResult, reportIsSafe);
    }
}