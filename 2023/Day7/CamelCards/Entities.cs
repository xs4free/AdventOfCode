namespace CamelCards;

internal enum HandType
{
    FiveOfAKind = 7,
    FourOfAKind = 6,
    FullHouse = 5,
    ThreeOfAKind = 4,
    TwoPair = 3,
    OnePair = 2,
    HighCard = 1
};

internal record Bid(int Amount);

internal class Hand(string cards) : IComparable<Hand>
{
    public string Cards { get; } = cards;
    public HandType HandType => HandTypeParser.Get(Cards);
    
    public int CompareTo(Hand? other)
    {
        if (other == null)
        {
            return 10;
        }
        
        if (this.HandType > other.HandType)
        {
            return 2;
        }
        if (this.HandType < other.HandType)
        {
            return -2;
        }

        for (var index = 0; index < Cards.Length; index++)
        {
            var scoreThis = CardScorer.GetScore(Cards[index]);
            var scoreOther = CardScorer.GetScore(other.Cards[index]);

            if (scoreThis > scoreOther)
            {
                return 1;
            }

            if (scoreThis < scoreOther)
            {
                return -1;
            }
        }

        return 0;
    }
};