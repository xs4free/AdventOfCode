namespace HauntedWasteland;

internal static class MapReader
{
    public static Map Read(IEnumerable<string> lines)
    {
        var input = lines.ToList();
        var instructions = input.First();
        
        var nodeList = input.Skip(2).Select(ParseNode).ToList();
        
        var nodes = nodeList.ToDictionary(node => node.Name);
        LinkNodes(nodes);
        
        return new Map(instructions, nodes["AAA"]);
    }

    private static void LinkNodes(Dictionary<string, Node> nodes)
    {
        foreach (var node in nodes.Values)
        {
            node.Left = nodes[node.LeftId];
            node.Right = nodes[node.RightId];
        }
    }

    private static Node ParseNode(string line)
    {
        var split = line.Split(new[] { '=', '(', ',', ')' },
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        
        return new Node(split[0], split[1], split[2], null, null);
    }
}