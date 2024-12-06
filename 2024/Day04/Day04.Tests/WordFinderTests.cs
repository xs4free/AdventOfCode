namespace Day04.Tests;

public class WordFinderTests
{
    private readonly string[] _input =
    [
        "MMMSXXMASM", 
        "MSAMXMSMSA", 
        "AMXSXMAAMM",
        "MSAMASMSMX",
        "XMASAMXAMM",
        "XXAMMXXAMA",
        "SMSMSASXSS",
        "SAXAMASAAA",
        "MAMMMXMMMM",
        "MXMXAXMASX"
    ];
    
    [Fact]
    public void Test_Count_Example()
    {
        var wordToFind = "XMAS";

        var map = InputParser.Parse(_input);
        var result = WordFinder.Count(wordToFind, map);
        
        Assert.Equal(18, result);
    }
    
    [Fact]
    public void Test_CountX_Example()
    {
        var wordToFind = "MAS";

        var map = InputParser.Parse(_input);
        var result = WordFinder.CountX(wordToFind, map);
        
        Assert.Equal(9, result);
    }
    
}