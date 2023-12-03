namespace GearRatios.Tests;

public class EngineSchematicAnalyzerTests
{
    [Fact]
    public void SumOfPartNumbers_Example()
    {
        string input = """
                       467..114..
                       ...*......
                       ..35..633.
                       ......#...
                       617*......
                       .....+.58.
                       ..592.....
                       ......755.
                       ...$.*....
                       .664.598..
                       """;

        var lines = input.Split(Environment.NewLine);

        var sum = EngineSchematicAnalyzer.SumOfPartNumbers(lines);
        
        Assert.Equal(4361, sum);
    }
}