using FluentAssertions;
using Xunit;

namespace Day3_Binary_Diagnostic.UnitTests
{
    public class DiagnosticReportAnalyzerTests
    {
        private string[] diagnosticReport = {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        [Fact]
        public void Analyze_should_return_invalid_result_when_empty_report()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(new string[] { });

            results.Valid.Should().Be(false);
        }

        [Fact]
        public void Analyze_should_return_correct_GammaRate()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport); 

            results.GammaRate.Should().Be(22);
        }

        [Fact]
        public void Analyze_should_return_correct_EpsilonRate()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.EpsilonRate.Should().Be(9);
        }

        [Fact]
        public void Analyze_should_return_correct_PowerConsumption()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.PowerConsumption.Should().Be(198);
        }

        [Fact]
        public void Analyze_should_return_correct_OxygenGeneratorRating()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.OxygenGeneratorRating.Should().Be(23);
        }

        [Fact]
        public void Analyze_should_return_correct_CO2ScrubberRating()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.CO2ScrubberRating.Should().Be(10);
        }

        [Fact]
        public void Analyze_should_return_correct_LifeSupportRating()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.LifeSupportRating.Should().Be(230);
        }
    }
}