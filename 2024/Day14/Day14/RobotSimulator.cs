namespace Day14;

public static class RobotSimulator
{
    public static Position Simulate(Robot robot, int seconds, MapSize size)
    {
        var newPosition = robot.Position;
        
        for (var i = 0; i < seconds; i++)
        {
            newPosition = NextPosition(robot.Velocity, size, newPosition);
        }

        return newPosition;
    }

    public static Position NextPosition(Velocity velocity, MapSize size, Position position)
    {
        var newX = position.X + velocity.X;
        if (newX < 0)
        {
            newX = size.Width + newX;
        }
        else if (newX >= size.Width)
        {
            newX = newX - size.Width;
        }

        var newY = position.Y + velocity.Y;
        if (newY < 0)
        {
            newY = size.Height + newY;
        }
        else if (newY >= size.Height)
        {
            newY = newY - size.Height;
        }

        position = new(newX, newY);
        
        return position;
    }
}