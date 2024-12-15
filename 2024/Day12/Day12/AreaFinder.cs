namespace Day12;

public static class AreaFinder
{
    public static IEnumerable<Area> Find(char[][] map)
    {
        HashSet<Position> processedPositions = new();
        
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                var position = new Position(x, y);

                if (processedPositions.Contains(position))
                {
                    continue;
                }
                
                var area = GetArea(map, position);
                foreach (var areaPosition in area.Positions)
                {
                    processedPositions.Add(areaPosition);    
                }
                
                yield return area;
            }
        }
    }

    private static Area GetArea(char[][] map, Position startPosition)
    {
        var plant = map[startPosition.Y][startPosition.X];
        return new Area(plant, GetAreaPositions(map, plant, startPosition, new()));
    }

    private static IEnumerable<Position> GetAreaPositions(char[][] map, char plant, Position position, HashSet<Position> visited)
    {
        if (position.Y < 0 || position.Y >= map.Length ||
            position.X < 0 || position.X >= map[0].Length)
        {
            return [];
        }
        
        var currentPlant = map[position.Y][position.X];
        if (currentPlant != plant)
        {
            return [];
        }

        if (!visited.Add(position))
        {
            return [];
        }

        var result = new List<Position> { position };

        result.AddRange(GetAreaPositions(map, plant, position with { Y = position.Y - 1 }, visited)); //up
        result.AddRange(GetAreaPositions(map, plant, position with { Y = position.Y + 1 }, visited)); //down
        result.AddRange(GetAreaPositions(map, plant, position with { X = position.X - 1 }, visited)); //left
        result.AddRange(GetAreaPositions(map, plant, position with { X = position.X + 1 }, visited)); //right
        
        return result;
    }
}