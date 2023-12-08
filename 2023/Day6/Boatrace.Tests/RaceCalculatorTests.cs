namespace Boatrace.Tests
{
    public class RaceCalculatorTests
    {
        [Fact]
        public void CalculateMargin_Example()
        {
            const string input =
                """
                Time:      7  15   30
                Distance:  9  40  200                
                """;

            int margin = RaceCalculator.CalculateMargin(input.Split(Environment.NewLine));

            Assert.Equal(288, margin);
        }
    }
}