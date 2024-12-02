namespace Day02.Tests;

public class SafetyEvaluatorTests
{
    [Fact]
    public void Example()
    {
        string[] input = ["7 6 4 2 1","1 2 7 8 9","9 7 6 2 1","1 3 2 4 5","8 6 4 4 1","1 3 6 7 9"];
        
        var reports = InputParser.Parse(input);
        var safeReports = reports.Count(SafetyEvaluator.IsSafe);

        Assert.Equal(2, safeReports);
    }

    [Fact]
    public void Input1_Check()
    {
        string[] input = ["18 21 22 24 26 29 28"];
        var reports = InputParser.Parse(input);
        var safeReports = reports.Count(SafetyEvaluator.IsSafe);

        Assert.Equal(0, safeReports);
    }
}