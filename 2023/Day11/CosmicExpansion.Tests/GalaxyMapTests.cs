namespace CosmicExpansion.Tests;

public class GalaxyMapTests
{
    [Fact]
    public void SumShortestPaths_Example1()
    {
        const string input = """
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

        var sum = GalaxyMap.SumShortestPaths(input.Split(Environment.NewLine));
        
        Assert.Equal(374, sum);
    }
}