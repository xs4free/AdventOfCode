namespace Day08.Tests;

public class NodeLocatorTests
{
    private readonly string[] _input =
    [
        "............",
        "........0...",
        ".....0......",
        ".......0....",
        "....0.......",
        "......A.....",
        "............",
        "............",
        "........A...",
        ".........A..",
        "............",
        "............"
    ];
    
    [Fact]
    public void Locate_Example_Day1()
    {
        var map = InputParser.Parse(_input);
        var antiNodeLocations = AntinodeLocator.Locate(map, false);
        
        Assert.Equal(14, antiNodeLocations.Count());
    }
    
    [Fact]
    public void Locate_Example_Day2()
    {
        var map = InputParser.Parse(_input);
        var antiNodeLocations = AntinodeLocator.Locate(map, true);
        
        Assert.Equal(34, antiNodeLocations.Count());
    }
}