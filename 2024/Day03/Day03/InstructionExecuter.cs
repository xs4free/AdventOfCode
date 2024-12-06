namespace Day03;

public static class InstructionExecuter
{
    public static int Execute(IEnumerable<Instruction> instructions)
    {
        var enabled = true;
        var result = 0;
        
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case MulInstruction mulInstruction when enabled:
                    result += mulInstruction.Left * mulInstruction.Right;
                    break;
                case DoInstruction:
                    enabled = true;
                    break;
                case DontInstruction:
                    enabled = false;
                    break;
            }
        }
        
        return result;
    }
}