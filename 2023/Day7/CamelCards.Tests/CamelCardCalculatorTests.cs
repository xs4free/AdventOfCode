namespace CamelCards.Tests;

public class CamelCardCalculatorTests
{
    [Fact]
    public void TotalWinnings_Example()
    {
        const string input = """
                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483
                             """;

        var totalWinnings = CamelCardCalculator.TotalWinnings(input.Split(Environment.NewLine));

        Assert.Equal(6440, totalWinnings);
    }
}