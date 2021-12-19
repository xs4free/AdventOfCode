namespace Day1_SonarSweep
{
    public class Sonar
    {
        public Report CreateReport(IEnumerable<int> depths)
        {
            var report = new Report();

            int previousDepth = int.MinValue;
            int index = 0;

            foreach(int depth in depths)
            {
                AddDepth(report, index, previousDepth, depth);

                previousDepth = depth;
                index++;
            }

            return report;
        }

        private static void AddDepth(Report report, int index, int previousDepth, int newDepth)
        {
            if (index == 0)
            {
                report.Output.Add($"{newDepth} (N/A - no previous measurement)");
            }
            else
            {
                DepthDirection direction = DepthDirection.Equal;

                if (newDepth < previousDepth)
                {
                    direction = DepthDirection.Decreased;
                    report.Decreases++;
                }
                else if (newDepth > previousDepth)
                {
                    direction = DepthDirection.Increased;
                    report.Increases++;
                }

                report.Output.Add($"{newDepth} ({direction.ToString().ToLowerInvariant()})");
            }

            report.Lines++;
        }
    }
}
