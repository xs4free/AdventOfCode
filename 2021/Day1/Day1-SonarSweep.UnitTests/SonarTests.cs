using Xunit;
using FluentAssertions;

namespace Day1_SonarSweep.UnitTests
{
    public class SonarTests
    {
        [Fact]
        public void CreateReport_example_Lines()
        {
            int[] depths = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            int expectedLines = 10;

            Sonar sut = new();
            var report = sut.CreateReport(depths);

            report.Lines.Should().Be(expectedLines);
        }

        [Fact]
        public void CreateReport_example_Increases()
        {
            int[] depths = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            int expectedIncreases = 7;

            Sonar sut = new();
            var report = sut.CreateReport(depths);

            report.Increases.Should().Be(expectedIncreases);
        }

        [Fact]
        public void CreateReport_example_Decreases()
        {
            int[] depths = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            int expectedDecreases = 2;

            Sonar sut = new();
            var report = sut.CreateReport(depths);

            report.Decreases.Should().Be(expectedDecreases);
        }

        [Fact]
        public void CreateReport_example_Output()
        {
            int[] depths = { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            string[] expectedOutput = {
                "199 (N/A - no previous measurement)",
                "200 (increased)",
                "208 (increased)",
                "210 (increased)",
                "200 (decreased)",
                "207 (increased)",
                "240 (increased)",
                "269 (increased)",
                "260 (decreased)",
                "263 (increased)"
            };

            Sonar sut = new();
            var report = sut.CreateReport(depths);

            report.Output.Should().Equal(expectedOutput);
        }
    }
}