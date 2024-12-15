namespace Day13.Tests;

public class InputParserTests
{
    [Fact]
    public void Parse_Part1_Example()
    {
        string[] input = 
        [
            "Button A: X+94, Y+34",
            "Button B: X+22, Y+67",
            "Prize: X=8400, Y=5400",
            "",
            "Button A: X+26, Y+66",
            "Button B: X+67, Y+21",
            "Prize: X=12748, Y=12176"
        ];
        
        var result = InputParser.Parse(input).ToList();

        Assert.Equal(2, result.Count);
        
        Assert.Equal(new Button('A', new ButtonOffset(94, 34), 3), result[0].Buttons[0]);
        Assert.Equal(new Button('B', new ButtonOffset(22, 67), 1), result[0].Buttons[1]);
        Assert.Equal(new Location(8400, 5400), result[0].PrizeLocation);
        
        Assert.Equal(new Button('A', new ButtonOffset(26, 66), 3), result[1].Buttons[0]);
        Assert.Equal(new Button('B', new ButtonOffset(67, 21), 1), result[1].Buttons[1]);
        Assert.Equal(new Location(12748, 12176), result[1].PrizeLocation);
    }
}