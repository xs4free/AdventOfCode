namespace CamelCards.Tests;

public class CamelCardCalculatorTests
{
    private const string Input = """
                         32T3K 765
                         T55J5 684
                         KK677 28
                         KTJJT 220
                         QQQJA 483
                         """;
    [Fact]
    public void TotalWinningsPart1_Example()
    {
        var totalWinnings = CamelCardCalculator.TotalWinningsPart1(Input.Split(Environment.NewLine));

        Assert.Equal(6440, totalWinnings);
    }
    
    [Fact]
    public void TotalWinningsPart2_Example()
    {
        var totalWinnings = CamelCardCalculator.TotalWinningsPart2(Input.Split(Environment.NewLine));

        Assert.Equal(5905, totalWinnings);
    }
}