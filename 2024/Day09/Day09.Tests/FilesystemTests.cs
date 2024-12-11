namespace Day09.Tests;

public class FilesystemTests
{
    [Theory]
    [InlineData("2333133121414131402", 1928)]
    public void Checksum_Part1_Example(string input, int expected)
    {
        var map = InputParser.Parse(input);
        var defraggedMap = Defragger.Defrag(map);
        var result = Filesystem.Checksum(defraggedMap);
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Checksum_Part1_Diskmap_Example()
    {
        var defraggedMap = new Diskmap
        {
            Sectors = SectorFactory.CreateSectorsFromString("0099811188827773336446555566..............").ToList()
        };
        var result = Filesystem.Checksum(defraggedMap);
        
        Assert.Equal(1928, result);
    }
}