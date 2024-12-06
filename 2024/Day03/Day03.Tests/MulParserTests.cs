namespace Day03.Tests;

public class MulParserTests
{
    [Fact]
    public void Parse_ExampleInput()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        var instructions = MulParser.Parse(input).ToArray();
        
        Assert.Equal(4, instructions.Length);
        
        Assert.Equal(2, instructions[0].Left);
        Assert.Equal(4, instructions[0].Right);
        
        Assert.Equal(5, instructions[1].Left);
        Assert.Equal(5, instructions[1].Right);

        Assert.Equal(11, instructions[2].Left);
        Assert.Equal(8, instructions[2].Right);
        
        Assert.Equal(8, instructions[3].Left);
        Assert.Equal(5, instructions[3].Right);
    }
}