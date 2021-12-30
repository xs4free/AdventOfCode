using System.Text;

namespace Day3_Binary_Diagnostic
{
    public class DiagnosticReportAnalyzer
    {
        public AnalyzerResults Analyze(IEnumerable<string> report)
        {
            if (!report.Any())
            {
                return new AnalyzerResults { Valid = false };
            }

            int[,] counters = CountBits(report);

            int gammaRate = GetRate(counters, mostCommonValue: true);
            int epsilonRate = GetRate(counters, mostCommonValue: false);

            int oxygenGeneratorRating = GetRating(report, mostCommonValue: true);
            int co2ScrubberRating = GetRating(report, mostCommonValue: false);

            return new AnalyzerResults
            {
                Valid = true,
                GammaRate = gammaRate,
                EpsilonRate = epsilonRate,
                PowerConsumption = gammaRate * epsilonRate,
                OxygenGeneratorRating = oxygenGeneratorRating,
                CO2ScrubberRating = co2ScrubberRating,
                LifeSupportRating = oxygenGeneratorRating * co2ScrubberRating
            };
        }

        private int GetRating(IEnumerable<string> report, int charIndex = 0, bool mostCommonValue = false)
        {
            if (report.Count() == 1)
            {
                return Convert.ToInt32(report.First(), 2);
            }    

            var lineChars = report.Select(line => new RatingGroupItem { Char = line[charIndex], Line = line });
            var groupedChars = lineChars.GroupBy(lineChars => lineChars.Char);
            
            var firstGroup = groupedChars.First();
            var secondGroup = groupedChars.Last();

            int firstCount = firstGroup.Count();
            int secondCount = secondGroup.Count();

            IGrouping<char, RatingGroupItem> group;

            if (firstCount > secondCount)
            {
                group = mostCommonValue ? firstGroup : secondGroup;
            }
            else if (firstCount == secondCount)
            {
                group = firstGroup.Key == '1' && mostCommonValue ? firstGroup : secondGroup;
            }
            else
            {
                group = mostCommonValue ? secondGroup : firstGroup;
            }

            return GetRating(group.Select(groupItem => groupItem.Line), ++charIndex, mostCommonValue);
        }

        private static int[,] CountBits(IEnumerable<string> report)
        {
            int numberOfBits = report.First().Length;
            int[,] counters = new int[numberOfBits, 2];

            foreach (var line in report)
            {
                for (int bitIndex = 0; bitIndex < numberOfBits; bitIndex++)
                {
                    if (line[bitIndex] == '0')
                    {
                        counters[bitIndex, 0]++;
                    }
                    else
                    {
                        counters[bitIndex, 1]++;
                    }
                }
            }

            return counters;
        }

        private int GetRate(int[,] counters, bool mostCommonValue)
        {
            StringBuilder gammaRate = new ();

            for(int index = 0; index <= counters.GetUpperBound(0); index++)
            {
                if (mostCommonValue)
                {
                    gammaRate.Append(counters[index, 0] > counters[index, 1] ? '0' : '1');
                }
                else
                {
                    gammaRate.Append(counters[index, 0] < counters[index, 1] ? '0' : '1');
                }
            }

            string txtGammaRate = gammaRate.ToString();
            return Convert.ToInt32(txtGammaRate, 2);
        }
    }
}
