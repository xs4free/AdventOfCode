namespace Scratchcards;

public record Card(int Id, IEnumerable<int> WinningNumbers, IEnumerable<int> CardNumbers);