using System.Text.RegularExpressions;

namespace Day03;

public static class InstructionParser
{
    private static readonly Regex RegexMul = new(@"(mul\((?<left>\d+),(?<right>\d+)\))|(don't\(\))|(do\(\))", RegexOptions.Compiled);
    public static IEnumerable<Instruction> Parse(string input)
    {
        foreach (Match match in RegexMul.Matches(input))
        {
            if (match.Value.Contains("mul", StringComparison.OrdinalIgnoreCase))
            {
                yield return new MulInstruction(int.Parse(match.Groups["left"].Value), int.Parse(match.Groups["right"].Value));
            }
            else if (match.Value.Contains("don't", StringComparison.OrdinalIgnoreCase))
            {
                yield return new DontInstruction();
            }
            else if (match.Value.Contains("do", StringComparison.OrdinalIgnoreCase))
            {
                yield return new DoInstruction();
            }
        }
    }
}