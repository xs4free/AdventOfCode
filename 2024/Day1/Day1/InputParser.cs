namespace Day1;

public static class InputParser
{
    public static (IEnumerable<int>, IEnumerable<int>) Parse(string[] lines)
    {
        var result1 = new int[lines.Length];
        var result2 = new int[lines.Length];
        
        for(var index = 0; index < lines.Length; index++)
        {
            var line = lines[index];
            var columns = line.Split("   ");
            result1[index] = int.Parse(columns[0]);
            result2[index] = int.Parse(columns[1]);
        }
        
        return (result1, result2);
    }
}