namespace CamelCards;

internal class HandComparer(IHandTypeParser handTypeParser, ICardScorer scorer) : IComparer<Hand?>
{
    public int Compare(Hand? hand1, Hand? hand2)
    {
        if (hand1 == null && hand2 == null)
        {
            return 0;
        }

        if (hand1 == null)
        {
            return -1;
        }

        if (hand2 == null)
        {
            return 1;
        }
        
        var handType1 = handTypeParser.Parse(hand1.Cards);
        var handType2 = handTypeParser.Parse(hand2.Cards);
        
        if (handType1 > handType2)
        {
            return 2;
        }
        if (handType1 < handType2)
        {
            return -2;
        }

        for (var index = 0; index < hand1.Cards.Length; index++)
        {
            var score1 = scorer.GetScore(hand1.Cards[index]);
            var score2 = scorer.GetScore(hand2.Cards[index]);

            if (score1 > score2)
            {
                return 3;
            }

            if (score1 < score2)
            {
                return -3;
            }
        }

        return 0;
    }
}