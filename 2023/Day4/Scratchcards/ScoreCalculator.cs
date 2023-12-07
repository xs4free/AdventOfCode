namespace Scratchcards;

public static class ScoreCalculator
{
    public static int ScoreCards(IEnumerable<string> lines)
    {
        return ParseInput2Cards(lines).Sum(ScoreCard);
    }
    
    public static int CountTotalCards(IEnumerable<string> lines)
    {
        var scoredCards = ParseInput2Cards(lines)
            .Select(card => new ScoredCard { Id = card.Id, CountWinningNumbers = CountWinningNumbers(card), Copies = 1 })
            .ToDictionary(score => score.Id);

        AddWinningCopies(scoredCards);

        return scoredCards.Sum(score => score.Value.Copies);
    }

    private static void AddWinningCopies(Dictionary<int, ScoredCard> scoredCards)
    {
        foreach (var (id, score) in scoredCards)
        {
            for (int cardIdToCopy = id + 1; cardIdToCopy <= id + score.CountWinningNumbers; cardIdToCopy++)
            {
                if (scoredCards.TryGetValue(cardIdToCopy, out var card))
                {
                    card.Copies += score.Copies;
                }
            }
        }
    }

    private static int ScoreCard(Card card)
    {
        var count= CountWinningNumbers(card);
        return count == 0 ? 0 : 1 << count - 1; // 1 2 4 8 16 ...
    }

    private static int CountWinningNumbers(Card card) => card.CardNumbers.Intersect(card.WinningNumbers).Count();

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