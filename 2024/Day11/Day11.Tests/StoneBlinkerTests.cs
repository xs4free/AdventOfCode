namespace Day11.Tests
{
    public class StoneBlinkerTests
    {


        [Theory]
        [InlineData("125 17", 1, "253000 1 7")]
        [InlineData("125 17", 2, "253 0 2024 14168")]
        [InlineData("125 17", 3, "512072 1 20 24 28676032")]
        [InlineData("125 17", 4, "512 72 2024 2 0 2 4 2867 6032")]
        [InlineData("125 17", 5, "1036288 7 2 20 24 4048 1 4048 8096 28 67 60 32")]
        [InlineData("125 17", 6, "2097446912 14168 4048 2 0 2 4 40 48 2024 40 48 80 96 2 8 6 7 6 0 3 2")]
        public void Score_Part1_Example(string input, int blink, string expectedStones)
        {
            var stones = InputParser.Parse(input);
            var expectedCount = expectedStones.Split(" ").Length;

            var blinkedStones = StoneBlinker.Blink(stones, blink);

            Assert.Equal(expectedCount, blinkedStones.Count);
            Assert.Equal(expectedStones, string.Join(' ', blinkedStones));
        }

        [Fact]
        public void Score_Part1_Example_25()
        {
            var stones = InputParser.Parse("125 17");

            var blinkedStones = StoneBlinker.Blink(stones, 25);

            Assert.Equal(55312, blinkedStones.Count);
        }
    }
}