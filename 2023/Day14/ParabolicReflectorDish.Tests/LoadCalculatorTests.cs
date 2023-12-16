namespace ParabolicReflectorDish.Tests;

public class LoadCalculatorTests
{
    [Fact]
    public void Calculate_Example()
    {
        const string input = """
                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....
                             """;

        var load = LoadCalculator.Calculate(input.Split(Environment.NewLine));
        
        Assert.Equal(136, load);
    }
}