namespace Day02;

public static class SafetyEvaluator
{
    public static bool IsSafe(Report report, bool useDampening = false)
    {
        if (report.Levels.Length < 2)
        {
            return false;
        }

        CountingDirection? initialDirection = null;
        
        for (var i = 0; i < report.Levels.Length - 1; i++)
        {
            var n1 = report.Levels[i];
            var n2 = report.Levels[i + 1];

            if (!IsSafe(n1, n2, initialDirection))
            {
                if (!useDampening)
                {
                    return false;
                }

                var result = false;
                
                if (i > 0)
                {
                    var reportWithoutI0 = new Report { Levels = report.Levels.Take(i - 1).Concat(report.Levels.Skip(i)).ToArray() };
                    result |= IsSafe(reportWithoutI0, false);
                }
                
                var reportWithoutI1 = new Report { Levels = report.Levels.Take(i).Concat(report.Levels.Skip(i+1)).ToArray() };
                result |= IsSafe(reportWithoutI1, false);
                
                var reportWithoutI2 = new Report { Levels = report.Levels.Take(i+1).Concat(report.Levels.Skip(i+2)).ToArray() };
                result |= IsSafe(reportWithoutI2, false);

                return result;
            }

            initialDirection ??= GetCountingDirection(n1, n2);
        }

        return true;
    }

    private static bool IsSafe(int level1, int level2, CountingDirection? initialDirection)
    {
        var diff = level2 - level1;

        if (diff is > 3 or < -3 or 0) 
        {
            return false;
        }

        var direction = GetCountingDirection(level1, level2);

        if (initialDirection != null && direction != initialDirection)
        {
            return false;
        }

        switch (direction)
        {
            case CountingDirection.Equal:
            case CountingDirection.Up when diff < 0:
            case CountingDirection.Down when diff > 0:
                return false;
            default:
                return true;
        }
    }

    private static CountingDirection GetCountingDirection(int level1, int level2)
    {
        if (level1 == level2)
        {
            return CountingDirection.Equal;
        }
        
        return level1 < level2 ? CountingDirection.Up : CountingDirection.Down;
    }
}