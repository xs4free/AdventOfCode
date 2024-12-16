namespace Day14;

public record Position(int X, int Y);
public record Velocity(int X, int Y);
public record MapSize(int Width, int Height);

public record Robot(Position Position, Velocity Velocity);