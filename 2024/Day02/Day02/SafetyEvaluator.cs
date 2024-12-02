namespace Day02;

public static class SafetyEvaluator
{
    public static bool IsSafe(Report report)
    {
        if (report.Levels.Count < 2)
        {
            return false;
        }

        if (report.Levels[0] == report.Levels[1])
        {
            return false;
        }
        
        var countingUp = report.Levels[0] < report.Levels[1];

        for (var i = 0; i < report.Levels.Count - 1; i++)
        {
            var diff = report.Levels[i + 1] - report.Levels[i];

            if (diff > 3 
                || diff < -3 
                || diff == 0 
                || (countingUp && diff < 0)
                || (!countingUp && diff > 0))
            {
                return false;
            }
        }

        return true;
    }
}