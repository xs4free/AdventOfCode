namespace CamelCards;

internal interface IHandTypeParser
{
    HandType Parse(string cards);
}

internal class HandTypeParserPart1 : IHandTypeParser
{
    public HandType Parse(string cards)
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


internal class HandTypeParserPart2 : IHandTypeParser
{
    public HandType Parse(string cards)
    {
        var groups = cards.GroupBy(card => card).ToList();
        int jokerCount = groups.FirstOrDefault(group => group.Key == 'J')?.Count() ?? 0;

        if ((groups.Count == 1 && groups.Any(group => group.Count() == 5))
            || groups.Count == 2 && jokerCount > 0)
        {
            return HandType.FiveOfAKind;
        }

        if ((groups.Count() == 2 && groups.Any(group => group.Count() == 4))
            || groups.Count() == 3 && groups.Any(group => group.Count() + jokerCount == 4))
        {
            return HandType.FourOfAKind;
        }

        if (groups.Count() == 2 ||
            groups.Count() == 3 && jokerCount > 0)
        {
            return HandType.FullHouse;
        }

        if ((groups.Count() == 3 && groups.Any(group => group.Count() == 3))
            || groups.Count() == 4 && groups.Any(group => group.Count() + jokerCount == 3))
        {
            return HandType.ThreeOfAKind;
        }

        if ((groups.Count() == 3 && groups.Count(group => group.Count() == 2) == 2) 
            || groups.Count() == 4 && groups.Count(group => group.Count() + jokerCount == 2) == 2)
        {
            return HandType.TwoPair;
        }

        if (groups.Count() == 4
            || (groups.Count() == 5 && jokerCount > 0))
        {
            return HandType.OnePair;
        }

        return HandType.HighCard;
    }
}