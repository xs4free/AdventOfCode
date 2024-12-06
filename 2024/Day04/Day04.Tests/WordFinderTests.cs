namespace Day04.Tests;

public class WordFinderTests
{
    [Fact]
    public void TestExample()
    {
        string[] input =
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
        var wordToFind = "XMAS";

        var map = InputParser.Parse(input);
        var result = WordFinder.Count(wordToFind, map);
        
        Assert.Equal(18, result);
    }
}