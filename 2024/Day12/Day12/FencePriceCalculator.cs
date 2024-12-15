namespace Day12;

public static class FencePriceCalculator
{
    public static int CalculatePerimeter(char[][] map)
    {
        var price = 0;
        var areas = AreaFinder.Find(map);
        
        foreach (var area in areas)
        {
            var fences = FenceLocator.Locate(area);
            price += fences.Count() * area.Positions.Count();
        }
        
        return price;
    }

    public static int CalculateSides(char[][] map)
    {
        var price = 0;
        var areas = AreaFinder.Find(map);
        
        foreach (var area in areas)
        {
            var fences = FenceLocator.Locate(area).ToList();
            var sides = CountSides(fences);

            price += sides * area.Positions.Count();
        }
        
        return price;
    }

    private static int CountSides(List<Fence> fences)
    {
        var sides = 0;
        
        foreach (var direction in Enum.GetValues(typeof(Direction)).Cast<Direction>())
        {
            var fencesInDirecion = fences.Where(fence => fence.Direction == direction).ToList();
            var orderedFencesInDirecion = direction is Direction.Up or Direction.Down 
                ? fencesInDirecion.OrderBy(fence => fence.Position.Y).ThenBy(fence => fence.Position.X)
                : fencesInDirecion.OrderBy(fence => fence.Position.X).ThenBy(fence => fence.Position.Y);
            sides += CountUninterruptedFences(orderedFencesInDirecion.ToList(), direction);
        }

        return sides;
    }

    private static int CountUninterruptedFences(List<Fence> orderedFences, Direction direction)
    {
        var sides = 1;
        var previousPosition = orderedFences.First().Position;
        
        foreach (var fence in orderedFences.Skip(1))
        {
            switch (direction)
            {
                case Direction.Up or Direction.Down when
                    fence.Position.X != previousPosition.X + 1 ||
                    fence.Position.Y != previousPosition.Y:
                case Direction.Left or Direction.Right when
                    fence.Position.Y != previousPosition.Y + 1 ||  
                    fence.Position.X != previousPosition.X:
                    sides++;
                    break;
            }

            previousPosition = fence.Position;
        }

        return sides;
    }
}