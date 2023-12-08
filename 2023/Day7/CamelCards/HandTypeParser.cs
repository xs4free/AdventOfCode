namespace CamelCards;

internal static class HandTypeParser
{
    public static HandType Get(string cards)
    {
        var groups = cards.GroupBy(card => card).ToList();

        if (groups.Count == 1
            && groups.Any(group => group.Count() == 5))
        {
            return HandType.FiveOfAKind;
        }

        if (groups.Count() == 2
            && groups.Any(group => group.Count() == 4))
        {
            return HandType.FourOfAKind;
        }

        if (groups.Count() == 2)
        {
            return HandType.FullHouse;
        }

        if (groups.Count() == 3
            && groups.Any(group => group.Count() == 3))
        {
            return HandType.ThreeOfAKind;
        }

        if (groups.Count() == 3
            && groups.Count(group => group.Count() == 2) == 2)
        {
            return HandType.TwoPair;
        }

        if (groups.Count() == 4)
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }
}