namespace Day12;

public static class FenceLocator
{
    public static IEnumerable<Fence> Locate(Area area)
    {
        var positionsInArea = area.Positions.ToHashSet();

        foreach (var position in area.Positions)
        {
            if (!positionsInArea.Contains(position with { Y = position.Y - 1 }))
            {
                yield return new Fence(position, Direction.Up);
            }
            if (!positionsInArea.Contains(position with { Y = position.Y + 1 }))
            {
                yield return new Fence(position, Direction.Down);
            }
            if (!positionsInArea.Contains(position with { X = position.X - 1 }))
            {
                yield return new Fence(position, Direction.Left);
            }
            if (!positionsInArea.Contains(position with { X = position.X + 1 }))
            {
                yield return new Fence(position, Direction.Right);
            }
        }
    }
}