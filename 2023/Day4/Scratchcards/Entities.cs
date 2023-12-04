namespace Scratchcards;

public record Card(int Id, IEnumerable<int> WinningNumbers, IEnumerable<int> CardNumbers);

public record ScoredCard
{
    public int Id { get; init; }
    public int CountWinningNumbers { get; init; }
    public int Copies { get; set; }
}
