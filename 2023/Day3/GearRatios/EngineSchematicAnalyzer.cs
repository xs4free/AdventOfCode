namespace GearRatios;

public class EngineSchematicAnalyzer
{
    public static int SumOfPartNumbers(string[] input)
    {
        var array = GetArray(input);
        var numbers = GetPartNumbers(array).ToList();

        return numbers.Sum();
    }

    private static IEnumerable<int> GetPartNumbers(char[][] array)
    {
        for (var row = 0; row < array.Length; row++)
        {
            for (var column = 0; column < array[row].Length; column++)
            {
                if (!IsPartNumber(row, column, array))
                {
                    continue;
                }
                
                var indexes = GetDigitIndexes(column, array[row]);

                var charsNumber = array[row].Skip(indexes.start).Take(indexes.end - indexes.start + 1).ToArray();
                var number = Convert.ToInt32(new string(charsNumber));
                yield return number;
                    
                // skip past last digit of found part number
                column = indexes.end;
            }
        }
    }

    private static (int start, int end) GetDigitIndexes(int startColumnIndex, char[] row)
    {
        if (!IsDigit(row[startColumnIndex]))
        {
            throw new InvalidDataException(
                $"Position '{startColumnIndex}' in string '{new string(row)}' should have been a digit");
        }

        var firstDigitIndex = startColumnIndex;
        var lastDigitIndex = startColumnIndex;

        while (firstDigitIndex - 1 >= 0
               && IsDigit(row[firstDigitIndex - 1]))
        {
            firstDigitIndex--;
        }
        
        while (lastDigitIndex + 1 < row.Length
               && IsDigit(row[lastDigitIndex + 1]))
        {
            lastDigitIndex++;
        } 

        return (firstDigitIndex, lastDigitIndex);
    }

    private static bool IsDigit(char chr)
    {
        return chr is '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9';
    }

    private static bool IsPartNumber(int row, int column, char[][] array)
    {
        if (!IsDigit(array[row][column]))
        {
            return false;
        }
        
        var surroundingCharacters = new List<char>();
        
        // row above
        if (row > 0)
        {
            if (column > 0)
            {
                surroundingCharacters.Add(array[row-1][column-1]);
            }
            
            surroundingCharacters.Add(array[row-1][column]);
            
            if (column + 1 < array[row-1].Length)
            {
                surroundingCharacters.Add(array[row - 1][column + 1]);
            }
        }

        // current row
        if (column > 0)
        {
            surroundingCharacters.Add(array[row][column-1]);
        }
        if (column + 1 < array[row].Length)
        {
            surroundingCharacters.Add(array[row][column + 1]);
        }

        // row below
        if (row + 1 < array.Length)
        {
            if (column > 0)
            {
                surroundingCharacters.Add(array[row + 1][column - 1]);
            }
            
            surroundingCharacters.Add(array[row + 1][column]);
            
            if (column + 1 < array[row + 1].Length)
            {
                surroundingCharacters.Add(array[row + 1][column + 1]);
            }
        }

        return surroundingCharacters.Any(chr => chr != '.' && !IsDigit(chr));
    }

    private static char[][] GetArray(IEnumerable<string> lines)
    {
        return lines.Select(line => line.ToCharArray()).ToArray();
    }
}