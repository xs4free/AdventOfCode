namespace Day09.Tests;

public class DefraggerTests
{
    [Theory]
    [InlineData("0.", "0.")]
    [InlineData(".0", "0.")]
    [InlineData("0.1", "01.")]
    [InlineData("0.11", "011.")]
    [InlineData("0..111....22222", "022111222......")]
    [InlineData("00...111...2...333.44.5555.6666.777.888899", "0099811188827773336446555566..............")]
    public void Defrag_Part1(string input, string expected)
    {
        var map = new Diskmap
        {
            Sectors = SectorFactory.CreateSectorsFromString(input).ToList()
        };
        
        var result = Defragger.DefragSectors(map);
        
        SectorAssert.AssertSectors(result.Sectors, expected);
    }
}