namespace Day12.Tests;

public class AreaFinderTests
{
    [Fact]
    public void Find_Part1_Example()
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
        
        Assert.Equal(5, areas.Count);
        Assert.Contains(areas, area => area.Plant == 'A' && area.Positions.Count() == 4);
        Assert.Contains(areas, area => area.Plant == 'B' && area.Positions.Count() == 4);
        Assert.Contains(areas, area => area.Plant == 'C' && area.Positions.Count() == 4);
        Assert.Contains(areas, area => area.Plant == 'D' && area.Positions.Count() == 1);
        Assert.Contains(areas, area => area.Plant == 'E' && area.Positions.Count() == 3);
    }
}