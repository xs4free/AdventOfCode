namespace Day12.Tests;

public class FenceLocatorTests
{
    [Fact]
    public void Locate_Part1_Example1()
    {
        string[] input = 
        [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ];

        var map = InputParser.Parse(input);
        var areas = AreaFinder.Find(map).ToList();
        var fences = areas.SelectMany(area => FenceLocator.Locate(area));
        
        Assert.Equal(40, fences.Count());
    }
    
    [Fact]
    public void Locate_Part1_Example2()
    {
        string[] input = 
        [
            "OOOOO",
            "OXOXO",
            "OOOOO",
            "OXOXO",
            "OOOOO"
        ];

        var map = InputParser.Parse(input);
        var areas = AreaFinder.Find(map).ToList();
        var fences = areas.SelectMany(area => FenceLocator.Locate(area));
        
        Assert.Equal(52, fences.Count());
    }
}