using System.Text.RegularExpressions;

namespace Day03;

public static class MulParser
{
    private static readonly Regex RegexMul = new(@"mul\((?<left>\d+),(?<right>\d+)\)", RegexOptions.Compiled);
    public static IEnumerable<MulInstruction> Parse(string input)
    {
        foreach (Match match in RegexMul.Matches(input))
        {
            yield return new (int.Parse(match.Groups["left"].Value), int.Parse(match.Groups["right"].Value));
        }
    }
}