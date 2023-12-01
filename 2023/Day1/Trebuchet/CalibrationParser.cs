using System.Text.RegularExpressions;

namespace Trebuchet;

public static partial class CalibrationParser
{
    [GeneratedRegex(@"\d")]
    private static partial Regex FirstDigit();

    [GeneratedRegex(@"\d", RegexOptions.RightToLeft)]
    private static partial Regex LastDigit();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.IgnoreCase)]
    private static partial Regex FirstDigitWord();

    [GeneratedRegex(@"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft | RegexOptions.IgnoreCase)]
    private static partial Regex LastDigitWord();

    public static int Parse(string[] input, CalibrationParserMode mode)
    {
        int total = 0;

        foreach (var line in input)
        {
            var firstNumber = GetDigit(line, DigitPosition.First, mode);
            var lastNumber = GetDigit(line, DigitPosition.Last, mode);

            int number = (firstNumber * 10) + lastNumber;

            if (number > 99)
            {
                throw new InvalidDataException($"Unexpected value '{number}' found in line '{line}'");
            }

            total += number;
        }

        return total;
    }

    private static ushort GetDigit(string line, DigitPosition position, CalibrationParserMode mode)
    {
        Regex regex;
        if (position == DigitPosition.First)
        {
            regex = mode == CalibrationParserMode.Digits ? FirstDigit() : FirstDigitWord();
        }
        else
        {
            regex = mode == CalibrationParserMode.Digits ? LastDigit() : LastDigitWord();
        }

        string digit = regex.Match(line).Value;

        return ConvertTextToNumber(digit);
    }

    private static ushort ConvertTextToNumber(string text)
    {
        if (text.Length == 1)
        {
            return Convert.ToUInt16(text);
        }

        switch (text.ToLowerInvariant())
        {
            case "one": return 1;
            case "two": return 2;
            case "three": return 3;
            case "four": return 4;
            case "five": return 5;
            case "six": return 6;
            case "seven": return 7;
            case "eight": return 8;
            case "nine": return 9;
            default:
                throw new ArgumentException(nameof(text), $"Unable to convert text '{text}' to a number");
        }
    }
}

internal enum DigitPosition
{
    First,
    Last
}