namespace CamelCards;

internal interface ICardScorer
{
    int GetScore(char card);
}

internal class CardScorerPart1 : ICardScorer
{
    private static readonly Dictionary<char, int> Score = new ()
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'J', 11 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 }
    };

    public int GetScore(char card)
    {
        return Score[card];
    }
}

internal class CardScorerPart2 : ICardScorer
{
    private static readonly Dictionary<char, int> Score = new ()
    {
        { 'A', 14 },
        { 'K', 13 },
        { 'Q', 12 },
        { 'T', 10 },
        { '9', 9 },
        { '8', 8 },
        { '7', 7 },
        { '6', 6 },
        { '5', 5 },
        { '4', 4 },
        { '3', 3 },
        { '2', 2 },
        { 'J', 1 },
    };

    public int GetScore(char card)
    {
        return Score[card];
    }
}