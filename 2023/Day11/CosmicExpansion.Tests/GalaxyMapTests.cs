namespace CosmicExpansion.Tests;

public class GalaxyMapTests
{
    private const string Input = """
                         ...#......
                         .......#..
                         #.........
                         ..........
                         ......#...
                         .#........
                         .........#
                         ..........
                         .......#..
                         #...#.....
                         """;
    [Fact]
    public void SumShortestPaths_Example_Part1()
    {
        var sum = GalaxyMap.SumShortestPaths(Input.Split(Environment.NewLine), 2);
        
        Assert.Equal(374, sum);
    }

    [Fact]
    public void SumShortestPaths_Example_Part2_1()
    {
        var sum = GalaxyMap.SumShortestPaths(Input.Split(Environment.NewLine), 10);
        
        Assert.Equal(1030, sum);
    }
    
    [Fact]
    public void SumShortestPaths_Example_Part2_2()
    {
        var sum = GalaxyMap.SumShortestPaths(Input.Split(Environment.NewLine), 100);
        
        Assert.Equal(8410, sum);
    }
    
}