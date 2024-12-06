namespace Day03;

public static class MulExecuter
{
    public static int Execute(MulInstruction instruction)
    {
        return instruction.Left * instruction.Right;
    }
}