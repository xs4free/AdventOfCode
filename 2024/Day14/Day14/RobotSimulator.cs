namespace Day14;

public static class RobotSimulator
{
    public static Position Simulate(Robot robot, int seconds, MapSize size)
    {
        var newPosition = robot.Position;
        
        for (var i = 0; i < seconds; i++)
        {
            var newX = newPosition.X + robot.Velocity.X;
            if (newX < 0)
            {
                newX = size.Width + newX;
            }
            else if (newX >= size.Width)
            {
                newX = newX - size.Width;
            }

            var newY = newPosition.Y + robot.Velocity.Y;
            if (newY < 0)
            {
                newY = size.Height + newY;
            }
            else if (newY >= size.Height)
            {
                newY = newY - size.Height;
            }

            newPosition = new(newX, newY);
        }

        return newPosition;
    }
}