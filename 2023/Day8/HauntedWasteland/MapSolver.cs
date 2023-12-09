namespace HauntedWasteland;

public static class MapSolver
{
    public static int StepsTo(IEnumerable<string> input, string endElement = "ZZZ")
    {
        var map = MapReader.Read(input);

        return GetStepsToNonRecursive(map, endElement);
    }

    private static int GetStepsToNonRecursive(Map map, string endNodeName)
    {
        var steps = 0;
        var node = map.FirstNode;
        var instructionsIndex = 0;
        
        while (true)
        {
            if (node.Name == endNodeName)
            {
                return steps;
            }

            if (instructionsIndex >= map.Instructions.Length)
            {
                instructionsIndex = 0;
            }

            var nextNode = map.Instructions[instructionsIndex++] == 'L' ? node.Left : node.Right;
            // Console.WriteLine($"Step {steps} - Moving '{map.Instructions[instructionsIndex-1]}' from node '{node.Name}' to '{nextNode.Name}'");
            node = nextNode;
            steps++;
        }
    }
}