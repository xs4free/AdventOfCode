namespace Day07.Tests;

public class EquationTests
{
    [Theory]
    [InlineData("190: 10 19", true)]
    [InlineData("3267: 81 40 27", true)]
    [InlineData("83: 17 5", false)]
    [InlineData("156: 15 6", false)]
    [InlineData("7290: 6 8 6 15", false)]
    [InlineData("161011: 16 10 13", false)]
    [InlineData("192: 17 8 14", false)]
    [InlineData("21037: 9 7 18 13", false)]
    [InlineData("292: 11 6 16 20", true)]
    public void IsValid_Example_Day1(string input, bool expected)
    {
        var equation = InputParser.ParseInput([input]).ToList().First();
        
        Assert.Equal(expected, equation.IsValid([Operator.Add, Operator.Multiply]));
    }
    
    [Theory]
    [InlineData("190: 10 19", true)]
    [InlineData("3267: 81 40 27", true)]
    [InlineData("83: 17 5", false)]
    [InlineData("156: 15 6", true)]
    [InlineData("7290: 6 8 6 15", true)]
    [InlineData("161011: 16 10 13", false)]
    [InlineData("192: 17 8 14", true)]
    [InlineData("21037: 9 7 18 13", false)]
    [InlineData("292: 11 6 16 20", true)]
    public void IsValid_Example_Day2(string input, bool expected)
    {
        var equation = InputParser.ParseInput([input]).ToList().First();
        
        Assert.Equal(expected, equation.IsValid([Operator.Add, Operator.Multiply, Operator.Concatenation]));
    }
    
}