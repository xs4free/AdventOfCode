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
        public void GammaRate_should_be_correct()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport); 

            results.GammaRate.Should().Be(22);
        }

        [Fact]
        public void EpsilonRate_should_be_correct()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.EpsilonRate.Should().Be(9);
        }

        [Fact]
        public void PowerConsumption_should_be_correct()
        {
            var analyzer = new DiagnosticReportAnalyzer();
            var results = analyzer.Analyze(diagnosticReport);

            results.PowerConsumption.Should().Be(198);
        }
    }
}