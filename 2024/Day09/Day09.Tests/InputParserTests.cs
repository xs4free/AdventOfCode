namespace Day09.Tests;

public class InputParserTests
{
    [Fact]
    public void Parse_Part1_Example1()
    {
        var input = "12345";

        var result = InputParser.Parse(input);
        
        SectorAssert.AssertSectors(result.Sectors, "0..111....22222");
    }
}