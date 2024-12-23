namespace Day15;

public static class InputParser
{
    public static Input Parse(string[] input)
    {
        List<char[]> mapLines = [];
        List<char> moves = [];

        foreach (var line in input)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                // skip separator between map and moves
                continue;
            }
            
            if (line[0] == '#')
            {
                mapLines.Add(line.ToArray());
            }
            else
            {
                moves.AddRange(line.ToCharArray());
            }
        }
        
        return new Input(mapLines.ToArray(), moves.ToArray());
    }
}