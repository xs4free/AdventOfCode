namespace Trebuchet.Tests;

public class CalibrationParserTests
{
    [Fact]
    public void Parse_Example_Input_Part1()
    {
        string example = """
                         1abc2
                         pqr3stu8vwx
                         a1b2c3d4e5f
                         treb7uchet
                         """;

        string[] input = example.Split(Environment.NewLine);
       
        Assert.Equal(142, CalibrationParser.Parse(input, CalibrationParserMode.Digits));
    }

    [Fact]
    public void Parse_Example_Input_Part2()
    {
        string example = """
                         two1nine
                         eightwothree
                         abcone2threexyz
                         xtwone3four
                         4nineeightseven2
                         zoneight234
                         7pqrstsixteen
                         """;

        string[] input = example.Split(Environment.NewLine);

        Assert.Equal(281, CalibrationParser.Parse(input, CalibrationParserMode.DigitsAndWords));
    }

    [Fact]
    public void Parse_One_number_in_line()
    {
        string example = "a2bc";

        string[] input = example.Split(Environment.NewLine);
       
        Assert.Equal(22, CalibrationParser.Parse(input, CalibrationParserMode.Digits));
    }
}