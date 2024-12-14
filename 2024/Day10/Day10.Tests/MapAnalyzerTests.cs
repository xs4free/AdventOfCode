namespace Day10.Tests;

public class MapAnalyzerTests
{
    [Fact]
    public void CountTrailEnds_Part1_Example1()
    {
        string[] input =
        [
            "...0...",
            "...1...",
            "...2...",
            "6543456",
            "7.....7",
            "8.....8",
            "9.....9"
        ];

        var map = InputParser.Parse(input);
        
        var count = MapAnalyzer.CountTrailEnds(map);
        
        Assert.Equal(2, count);
    }
    
    [Fact]
    public void CountTrailEnds_Part1_Example2()
    {
        string[] input =
        [
            "10..9..",
            "2...8..",
            "3...7..",
            "4567654",
            "...8..3",
            "...9..2",
            ".....01"
        ];

        var map = InputParser.Parse(input);
        
        var count = MapAnalyzer.CountTrailEnds(map);
        
        Assert.Equal(3, count);
    }
 
    [Fact]
    public void CountTrailEnds_Part1_Example3()
    {
        string[] input =
        [
            "89010123",
            "78121874",
            "87430965",
            "96549874",
            "45678903",
            "32019012",
            "01329801",
            "10456732" 
        ];

        var map = InputParser.Parse(input);
        
        var count = MapAnalyzer.CountTrailEnds(map);
        
        Assert.Equal(36, count);
    }
}