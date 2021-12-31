using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Day4_Giant_Squid.UnitTests
{
    public class BoardAnalyzerTests
    {
        [Fact]
        public void Analyze_should_find_win()
        {
            Board board = new Board
            {
                Values = new int[5,5]
                {
                    { 14, 21, 17, 24,  4 },
                    { 10, 16, 15,  9, 19 },
                    { 18,  8, 23, 26, 20 },
                    { 22, 11, 13,  6,  5 },
                    {  2,  0, 12,  3,  7 }
                }
            };

            List<int> drawnNumbers = new() { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

            int[] unmarkedValues = new[] { 10, 16, 15, 19, 18, 8, 26, 20, 22, 13, 6, 12, 3 };
            int winningNumber = 24;

            BoardAnalyzer analyzer = new();
            var result = analyzer.Analyze(board, drawnNumbers);

            result.WinningNumber.Should().Be(winningNumber);
            result.Score.Should().Be(unmarkedValues.Sum() * winningNumber);
            result.WinningRound.Should().Be(drawnNumbers.FindIndex(number => number == winningNumber));
        }
    }
}