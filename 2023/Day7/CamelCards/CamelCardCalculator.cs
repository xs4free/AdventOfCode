namespace CamelCards;

public static class CamelCardCalculator
{
    public static int TotalWinnings(IEnumerable<string> lines)
    {
        var handBids = CamelCardInputReader.Read(lines).OrderBy(handBid => handBid.hand).ToList();

        var totalWinning = 0;
        for (var index = 0; index < handBids.Count; index++)
        {
            var rank = index + 1;
            totalWinning += handBids[index].bid.Amount * rank;
        }

        return totalWinning;
    }
}