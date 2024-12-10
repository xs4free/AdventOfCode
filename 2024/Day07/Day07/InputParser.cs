namespace Day07;

public static class InputParser
{
    public static IEnumerable<Equation> ParseInput(string[] input)
    {
        foreach (var line in input)
        {
            var values = line.Split([':', ' '], StringSplitOptions.RemoveEmptyEntries);
            var testValue = long.Parse(values[0]);
            var inputValues = values.Skip(1).Select(long.Parse).ToArray(); 
            
            yield return new (testValue, inputValues);
        }
    }
}