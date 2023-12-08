namespace Boatrace.Tests
{
    public class RaceCalculatorTests
    {
        private const string Input =
            """
            Time:      7  15   30
            Distance:  9  40  200
            """;
        
        [Fact]
        public void CalculateMargin_Example()
        {

            int margin = RaceCalculator.CalculateMargin(Input.Split(Environment.NewLine));

            Assert.Equal(288, margin);
        }
        
        [Fact]
        public void CalculateTotalMargin_Example()
        {
            long margin = RaceCalculator.CalculateTotalMargin(Input.Split(Environment.NewLine));

            Assert.Equal(71503, margin);
        }
    }
}