namespace CamelCards;

public static class CamelCardCalculator
{
    public static int TotalWinningsPart1(IEnumerable<string> lines)
    {
        var comparer = new HandComparer(new HandTypeParserPart1(), new CardScorerPart1());

        return TotalWinnings(comparer, lines);
    }

    public static int TotalWinningsPart2(IEnumerable<string> lines)
    {
        var comparer = new HandComparer(new HandTypeParserPart2(), new CardScorerPart2());

        return TotalWinnings(comparer, lines);
    }
    
    private static int TotalWinnings(IComparer<Hand?> comparer, IEnumerable<string> lines)
    {
        var handBids = CamelCardInputReader.Read(lines).OrderBy(handBid => handBid.hand, comparer).ToList();

        var totalWinning = 0;
        for (var index = 0; index < handBids.Count; index++)
        {
            var rank = index + 1;
            totalWinning += handBids[index].bid.Amount * rank;
        }

        return totalWinning;
    }
}