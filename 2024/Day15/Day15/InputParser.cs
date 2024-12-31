namespace Day15;

public static class InputParser
{
    public static Input ParseForPart1(string[] input)
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
    
    public static Input ParseForPart2(string[] input)
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
                List<char> expandedLine = [];
                foreach (var character in line)
                {
                    if (character == '#')
                    {
                        expandedLine.Add(character);
                        expandedLine.Add(character);
                    }
                    else if (character == 'O')
                    {
                        expandedLine.Add('[');
                        expandedLine.Add(']');
                    }
                    else if (character == '.')
                    {
                        expandedLine.Add('.');
                        expandedLine.Add('.');
                    }
                    else if (character == '@')
                    {
                        expandedLine.Add('@');
                        expandedLine.Add('.');
                    }
                }
                mapLines.Add(expandedLine.ToArray());
            }
            else
            {
                moves.AddRange(line.ToCharArray());
            }
        }
        
        return new Input(mapLines.ToArray(), moves.ToArray());
    }
}