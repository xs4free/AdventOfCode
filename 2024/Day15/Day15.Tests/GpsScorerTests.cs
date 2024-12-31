namespace Day15.Tests;

public class GpsScorerTests
{
    [Fact]
    public void Score_Part1_Example_1()
    {
        string[] input =
        [
            "######",
            "#...O#",
            "######",
        ];
        
        var (map, _) = InputParser.ParseForPart1(input);
        var result = GpsScorer.Score(map);
        
        Assert.Equal(104, result);
    }

    [Fact]
    public void Score_Part1_Example_Smaller()
    {
        string[] input =
        [
            "########",
            "#....OO#",
            "##.....#",
            "#.....O#",
            "#.#O@..#",
            "#...O..#",
            "#...O..#",
            "########"
        ];
        
        var (map, _) = InputParser.ParseForPart1(input);
        var result = GpsScorer.Score(map);
        
        Assert.Equal(2028, result);
    }
    
    [Fact]
    public void Score_Part1_Example_Large()
    {
        string[] input =
        [
            "##########",
            "#.O.O.OOO#",
            "#........#",
            "#OO......#",
            "#OO@.....#",
            "#O#.....O#",
            "#O.....OO#",
            "#O.....OO#",
            "#OO....OO#",
            "##########",
        ];
        
        var (map, _) = InputParser.ParseForPart1(input);
        var result = GpsScorer.Score(map);
        
        Assert.Equal(10092, result);
    }
    
    [Fact]
    public void Score_Part2_Example_Large()
    {
        string[] input =
        [
            "####################",
            "##[].......[].[][]##",
            "##[]...........[].##",
            "##[]........[][][]##",
            "##[]......[]....[]##",
            "##..##......[]....##",
            "##..[]............##",
            "##..@......[].[][]##",
            "##......[][]..[]..##",
            "####################",
        ];
        
        var (map, _) = InputParser.ParseForPart1(input);
        var result = GpsScorer.Score(map);
        
        Assert.Equal(9021, result);
    }
    
}