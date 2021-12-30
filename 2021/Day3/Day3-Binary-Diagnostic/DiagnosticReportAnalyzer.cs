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

            int gammaRate = GetRate(counters, mostCommon: true);
            int epsilonRate = GetRate(counters, mostCommon: false);

            return new AnalyzerResults
            {
                Valid = true,
                GammaRate = gammaRate,
                EpsilonRate = epsilonRate,
                PowerConsumption = gammaRate * epsilonRate
            };
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

        private int GetRate(int[,] counters, bool mostCommon)
        {
            StringBuilder gammaRate = new ();

            for(int index = 0; index <= counters.GetUpperBound(0); index++)
            {
                if (mostCommon)
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
