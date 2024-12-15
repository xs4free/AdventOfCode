namespace Day12;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
};

public record Position(int X, int Y);
public record Area(char Plant, IEnumerable<Position> Positions);

public record Fence(Position Position, Direction Direction);
