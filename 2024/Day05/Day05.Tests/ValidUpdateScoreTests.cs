namespace Day05.Tests;

public class ValidUpdateScoreTests
{
    private readonly string[] _input =
        [
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
            "",
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47"
        ];
    
    [Fact]
    public void Validate_Example_Score()
    {
        var parsedInput = InputParser.Parse(_input);
        var validUpdates = parsedInput.Updates.Where(update => UpdateValidator.IsValid(update, parsedInput.OrderingRules)).ToList();
        var score = ValidUpdateScore.Score(validUpdates);
        
        Assert.Equal(143, score);
    }
    
    [Fact]
    public void Fix_Invalid_Updates_Example_Score()
    {
        var parsedInput = InputParser.Parse(_input);
        var invalidUpdates = parsedInput.Updates.Where(update => !UpdateValidator.IsValid(update, parsedInput.OrderingRules)).ToList();
        var fixedUpdates = invalidUpdates.Select(invalidUpdate => UpdateValidator.Fix(invalidUpdate, parsedInput.OrderingRules)).ToList();
        var score = ValidUpdateScore.Score(fixedUpdates);
        
        Assert.Equal(123, score);
    }
}