namespace Day12.Tests;

public class FencePriceCalculatorTests
{
    [Fact]
    public void Calculate_Part1_Example1()
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
        var price = FencePriceCalculator.Calculate(map);

        Assert.Equal(772, price);
    }
    
    [Fact]
    public void Calculate_Part1_Example2()
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
        var price = FencePriceCalculator.Calculate(map);

        Assert.Equal(1930, price);
    }
}