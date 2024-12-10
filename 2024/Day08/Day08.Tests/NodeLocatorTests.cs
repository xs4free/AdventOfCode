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
        var antiNodeLocations = AntinodeLocator.Locate(map);
        
        Assert.Equal(14, antiNodeLocations.Count());
    }
}