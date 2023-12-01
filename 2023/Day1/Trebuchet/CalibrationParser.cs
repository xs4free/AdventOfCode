using System.Text.RegularExpressions;

namespace Trebuchet;

public static partial class CalibrationParser
{
    [GeneratedRegex(@"\d")]
    private static partial Regex FirstDigit();

    [GeneratedRegex(@"\d", RegexOptions.RightToLeft)]
    private static partial Regex LastDigit();
    
    public static int Parse(string[] input)
    {
        int total = 0;
        
        foreach (var line in input)
        {
            var firstDigitChar = FirstDigit().Match(line);
            var lastDigitChar = LastDigit().Match(line);
            var lineNumber = firstDigitChar.Value + lastDigitChar.Value;
            
            ushort number = Convert.ToUInt16(lineNumber);

            if (number > 99)
            {
                throw new InvalidDataException($"Unexpected value '{number}' found in line '{line}'");
            }

            total += number;
        }
        
        return total;
    }
}