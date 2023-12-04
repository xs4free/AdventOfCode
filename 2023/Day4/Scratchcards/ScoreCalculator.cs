namespace Scratchcards;

public static class ScoreCalculator
{
    public static int ScoreCards(IEnumerable<string> lines)
    {
        return ParseInput2Cards(lines).Sum(ScoreCard);
    }

    private static int ScoreCard(Card card)
    {
        var count= card.CardNumbers.Intersect(card.WinningNumbers).Count();
        return count == 0 ? 0 : 1 << count - 1; // 1 2 4 8 16 ...
    }

    private static List<Card> ParseInput2Cards(IEnumerable<string> lines) => lines.Select(ParseLine2Card).ToList();

    private static readonly char[] Separators = { ':', '|' };
    private const StringSplitOptions SplitOptions = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;

    private static Card ParseLine2Card(string line)
    {
        var split = line.Split(Separators, SplitOptions);
        
        var cardId = int.Parse(split[0].Split(' ',SplitOptions)[1]);
        var winningNumbers = split[1].Split(' ', SplitOptions).Select(int.Parse).ToList();
        var cardNumbers = split[2].Split(' ',SplitOptions).Select(int.Parse).ToList();
        
        return new Card(cardId, winningNumbers, cardNumbers);
    }
}