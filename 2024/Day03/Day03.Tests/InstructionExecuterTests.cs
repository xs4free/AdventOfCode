namespace Day03.Tests;

public class InstructionExecuterTests
{
    [Fact]
    public void Execute_Example()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        var instructions = InstructionParser.Parse(input);
        var result = InstructionExecuter.Execute(instructions);
        
        Assert.Equal(161, result);
    }

    [Fact]
    public void Execute_Example2()
    {
        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        var instructions = InstructionParser.Parse(input);
        var result = InstructionExecuter.Execute(instructions);
        
        Assert.Equal(48, result);
    }
}