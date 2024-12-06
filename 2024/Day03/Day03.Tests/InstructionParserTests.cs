namespace Day03.Tests;

public class InstructionParserTests
{
    [Fact]
    public void Parse_ExampleInput()
    {
        const string input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

        var instructions = InstructionParser.Parse(input).Cast<MulInstruction>().ToArray();
        
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
    
    [Fact]
    public void Parse_ExampleInput_Including_AllInstructions()
    {
        const string input = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";

        var instructions = InstructionParser.Parse(input).ToArray();
        
        Assert.Equal(6, instructions.Length);
        
        Assert.IsType<MulInstruction>(instructions[0]);
        Assert.Equal(2, ((MulInstruction)instructions[0]).Left);
        Assert.Equal(4, ((MulInstruction)instructions[0]).Right);

        Assert.IsType<DontInstruction>(instructions[1]);
        
        Assert.IsType<MulInstruction>(instructions[2]);
        Assert.Equal(5, ((MulInstruction)instructions[2]).Left);
        Assert.Equal(5, ((MulInstruction)instructions[2]).Right);

        Assert.IsType<MulInstruction>(instructions[3]);
        Assert.Equal(11, ((MulInstruction)instructions[3]).Left);
        Assert.Equal(8, ((MulInstruction)instructions[3]).Right);
        
        Assert.IsType<DoInstruction>(instructions[4]);
        
        Assert.IsType<MulInstruction>(instructions[5]);
        Assert.Equal(8, ((MulInstruction)instructions[5]).Left);
        Assert.Equal(5, ((MulInstruction)instructions[5]).Right);
    }
}