namespace Day12.Tests;

public class FencePriceCalculatorTests
{
    [Fact]
    public void CalculatePerimeter_Part1_Example1()
    {
        string[] input =
            [
                "OOOOO",
                "OXOXO",
                "OOOOO",
                "OXOXO",
                "OOOOO"
            ];

        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculatePerimeter(map);

        Assert.Equal(772, price);
    }
    
    [Fact]
    public void CalculatePerimeter_Part1_Example2()
    {
        string[] input =
        [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"
        ];

        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculatePerimeter(map);

        Assert.Equal(1930, price);
    }

    [Fact]
    public void CalculateSides_Part2_Example0()
    {
        string[] input =
        [
            "AAAA",
        ];
        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculateSides(map);

        Assert.Equal(16, price);
    }

    [Fact]
    public void CalculateSides_Part2_Example1()
    {
        string[] input =
        [
            "AAAA",
            "BBCD",
            "BBCC",
            "EEEC"
        ];
        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculateSides(map);

        Assert.Equal(80, price);
    }

    [Fact]
    public void CalculateSides_Part2_Example2()
    {
        string[] input =
        [
            "OOOOO",
            "OXOXO",
            "OOOOO",
            "OXOXO",
            "OOOOO"
        ];

        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculateSides(map);

        Assert.Equal(436, price);
    }

    [Fact]
    public void CalculateSides_Part2_Example3()
    {
        string[] input =
        [
            "EEEEE",
            "EXXXX",
            "EEEEE",
            "EXXXX",
            "EEEEE"
        ];

        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculateSides(map);

        Assert.Equal(236, price);
    }
    
    [Fact]
    public void CalculateSides_Part2_Example4()
    {
        string[] input =
        [
            "AAAAAA",
            "AAABBA",
            "AAABBA",
            "ABBAAA",
            "ABBAAA",
            "AAAAAA"
        ];

        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculateSides(map);

        Assert.Equal(368, price);
    }
    
    [Fact]
    public void CalculateSides_Part2_Example5()
    {
        string[] input =
        [
            "RRRRIICCFF",
            "RRRRIICCCF",
            "VVRRRCCFFF",
            "VVRCCCJFFF",
            "VVVVCJJCFE",
            "VVIVCCJJEE",
            "VVIIICJJEE",
            "MIIIIIJJEE",
            "MIIISIJEEE",
            "MMMISSJEEE"
        ];

        var map = InputParser.Parse(input);
        var price = FencePriceCalculator.CalculateSides(map);

        Assert.Equal(1206, price);
    }
}