namespace Day02;

public static class InputParser
{
    public static IEnumerable<Report> Parse(string[] lines)
    {
        return lines.Select(line => 
            new Report
            {
                Levels = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(level => Int32.Parse(level)).ToList()
            }).ToList();
    }
}