namespace GearRatios.Tests;

public class EngineSchematicAnalyzerTests
{
    [Fact]
    public void SumOfPartNumbers_Example()
    {
        const string input = """
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
    
    [Fact]
    public void SumOfGearRatios_Example()
    {
        const string input = """
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

        var sum = EngineSchematicAnalyzer.SumOfGearRatios(lines);
        
        Assert.Equal(467835, sum);
    }
    
}