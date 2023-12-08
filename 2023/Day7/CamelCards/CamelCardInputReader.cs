namespace CamelCards;

internal static class CamelCardInputReader
{
    public static IEnumerable<(Hand hand, Bid bid)> Read(IEnumerable<string> input)
    {
        return input.Select(line => line.Split(' '))
            .Select(parts => (new Hand(parts[0]), new Bid(int.Parse(parts[1]))));
    }
}