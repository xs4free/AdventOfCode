namespace ParabolicReflectorDish.Tests;

public class LoadCalculatorTests
{
    private const string Input = """
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
    [Fact]
    public void Calculate_Example()
    {
        var load = LoadCalculator.Calculate(Input.Split(Environment.NewLine));
        
        Assert.Equal(136, load);
    }
    
    [Fact]
    public void CycleDish_Example_1()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var cycledDish = LoadCalculator.CycleDish(dish, 1).Select(line => new string(line));

        const string expectedCycledDishInput = """
                                               .....#....
                                               ....#...O#
                                               ...OO##...
                                               .OO#......
                                               .....OOO#.
                                               .O#...O#.#
                                               ....O#....
                                               ......OOOO
                                               #...O###..
                                               #..OO#....
                                               """;
        var expectedCycledDish = expectedCycledDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedCycledDish.SequenceEqual(cycledDish));
    }

    [Fact]
    public void CycleDish_Example_2()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var cycledDish = LoadCalculator.CycleDish(dish, 2).Select(line => new string(line));

        const string expectedCycledDishInput = """
                                               .....#....
                                               ....#...O#
                                               .....##...
                                               ..O#......
                                               .....OOO#.
                                               .O#...O#.#
                                               ....O#...O
                                               .......OOO
                                               #..OO###..
                                               #.OOO#...O
                                               """;
        var expectedCycledDish = expectedCycledDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedCycledDish.SequenceEqual(cycledDish));
    }

    [Fact]
    public void CycleDish_Example_3()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var cycledDish = LoadCalculator.CycleDish(dish, 3).Select(line => new string(line));

        const string expectedCycledDishInput = """
                                               .....#....
                                               ....#...O#
                                               .....##...
                                               ..O#......
                                               .....OOO#.
                                               .O#...O#.#
                                               ....O#...O
                                               .......OOO
                                               #...O###.O
                                               #.OOO#...O
                                               """;
        var expectedCycledDish = expectedCycledDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedCycledDish.SequenceEqual(cycledDish));
    }
    
    [Fact]
    public void TiltDish_Example_North()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var tiltedDish = LoadCalculator.TiltDish(dish, TiltDirection.North).Select(line => new string(line));

        const string expectedTiltedDishInput = """
                                               OOOO.#.O..
                                               OO..#....#
                                               OO..O##..O
                                               O..#.OO...
                                               ........#.
                                               ..#....#.#
                                               ..O..#.O.O
                                               ..O.......
                                               #....###..
                                               #....#....
                                               """;
        var expectedTiltedDish = expectedTiltedDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedTiltedDish.SequenceEqual(tiltedDish));
    }

    [Fact]
    public void TiltDish_Example_West()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var tiltedDish = LoadCalculator.TiltDish(dish, TiltDirection.West).Select(line => new string(line));

        const string expectedTiltedDishInput = """
                                               O....#....
                                               OOO.#....#
                                               .....##...
                                               OO.#OO....
                                               OO......#.
                                               O.#O...#.#
                                               O....#OO..
                                               O.........
                                               #....###..
                                               #OO..#....
                                               """;
        var expectedTiltedDish = expectedTiltedDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedTiltedDish.SequenceEqual(tiltedDish));
    }

    [Fact]
    public void TiltDish_Example_South()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var tiltedDish = LoadCalculator.TiltDish(dish, TiltDirection.South).Select(line => new string(line));

        const string expectedTiltedDishInput = """
                                               .....#....
                                               ....#....#
                                               ...O.##...
                                               ...#......
                                               O.O....O#O
                                               O.#..O.#.#
                                               O....#....
                                               OO....OO..
                                               #OO..###..
                                               #OO.O#...O
                                               """;
        var expectedTiltedDish = expectedTiltedDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedTiltedDish.SequenceEqual(tiltedDish));
    }
    
    [Fact]
    public void TiltDish_Example_East()
    {
        var dish = Input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var tiltedDish = LoadCalculator.TiltDish(dish, TiltDirection.East).Select(line => new string(line));

        const string expectedTiltedDishInput = """
                                               ....O#....
                                               .OOO#....#
                                               .....##...
                                               .OO#....OO
                                               ......OO#.
                                               .O#...O#.#
                                               ....O#..OO
                                               .........O
                                               #....###..
                                               #..OO#....
                                               """;
        var expectedTiltedDish = expectedTiltedDishInput.Split(Environment.NewLine);
        
        Assert.True(expectedTiltedDish.SequenceEqual(tiltedDish));
    }
    
    [Fact]
    public void CalculateWithCycles_Example()
    {
        var sum = LoadCalculator.CalculateWithCycles(Input.Split(Environment.NewLine), 1000000000);
        
        Assert.Equal(64, sum);
    }
    
}