namespace Day03.Tests;

public class MulExecuterTests
{
    [Fact]
    public void Execute_Example()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        var instructions = MulParser.Parse(input);
        var result = instructions.Select(MulExecuter.Execute).Sum();
        
        Assert.Equal(161, result);
    }
}