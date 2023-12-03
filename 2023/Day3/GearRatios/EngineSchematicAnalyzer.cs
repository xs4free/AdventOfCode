namespace GearRatios;

public class EngineSchematicAnalyzer
{
    public static int SumOfPartNumbers(string[] input)
    {
        var array = GetArray(input);
        var numbers = GetPartNumbers(array).ToList();

        return numbers.Sum();
    }

    public static int SumOfGearRatios(string[] input)
    {
        var array = GetArray(input);
        var numbers = GetGearRatios(array).ToList();

        return numbers.Sum();
    }

    private static IEnumerable<int> GetGearRatios(char[][] array)
    {
        for (var row = 0; row < array.Length; row++)
        {
            for (var column = 0; column < array[row].Length; column++)
            {
                if (!IsGear(row, column, array))
                {
                    continue;
                }

                var numbersSurroundingGear = GetNumbersSurrounding(row, column, array).ToList();
                var gearRatio = numbersSurroundingGear[0] * numbersSurroundingGear[1];

                yield return gearRatio;
            }
        }
    }

    private static bool IsGear(int row, int column, char[][] array)
    {
        if (array[row][column] != '*')
        {
            return false;
        }

        IEnumerable<int> surroundingNumbers = GetNumbersSurrounding(row, column, array);
        return surroundingNumbers.Count() == 2;
    }

    private static IEnumerable<int> GetNumbersSurrounding(int row, int column, char[][] array)
    {
        var surrounding = GetSurroundingCharacters(row, column, array);

        for (int surroundingRow = 0; surroundingRow < 3; surroundingRow++)
        {
            bool[] isDigit = surrounding[surroundingRow].Select(IsDigit).ToArray();
            int arrayRow = row + (surroundingRow - 1);
            
            if (isDigit.All(digit => digit))
            {
                GetNumberAt(array, column, arrayRow, out int number);
                yield return number;
            }
            else if (isDigit[0] && isDigit[2])
            {
                GetNumberAt(array, column - 1, arrayRow, out int number1);
                yield return number1;
                
                GetNumberAt(array, column + 1, arrayRow, out int number2);
                yield return number2;
            }
            else if (isDigit[0])
            {
                GetNumberAt(array, column - 1, arrayRow, out int number);
                yield return number;
            }
            else if (isDigit[1])
            {
                GetNumberAt(array, column, arrayRow, out int number);
                yield return number;
            }
            else if (isDigit[2])
            {
                GetNumberAt(array, column + 1, arrayRow, out int number);
                yield return number;
            }
        }
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
                
                var indexes = GetNumberAt(array, column, row, out var number);
                yield return number;
                    
                // skip past last digit of found part number
                column = indexes.end;
            }
        }
    }

    private static (int start, int end) GetNumberAt(char[][] array, int column, int row, out int number)
    {
        var indexes = GetDigitIndexes(column, array[row]);

        var charsNumber = array[row].Skip(indexes.start).Take(indexes.end - indexes.start + 1).ToArray();
        number = Convert.ToInt32(new string(charsNumber));
        return indexes;
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

    private static bool IsDigit(char? chr)
    {
        return chr is '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9';
    }

    private static bool IsPartNumber(int row, int column, char[][] array)
    {
        if (!IsDigit(array[row][column]))
        {
            return false;
        }
        
        var surroundingCharacters = GetSurroundingCharacters(row, column, array);
        
        foreach (var surroundingRow in surroundingCharacters)
        {
            foreach (var chr in surroundingRow)
            {
                if (chr.HasValue
                    && chr.Value != '.'
                    && !IsDigit(chr.Value))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static char?[][] GetSurroundingCharacters(int row, int column, char[][] array)
    {
        var surroundingCharacters = new [] { new char?[3], new char?[3], new char?[3]};
        
        // row above
        if (row > 0)
        {
            if (column > 0)
            {
                surroundingCharacters[0][0] = array[row-1][column-1];
            }
            
            surroundingCharacters[0][1] = array[row-1][column];
            
            if (column + 1 < array[row-1].Length)
            {
                surroundingCharacters[0][2] = array[row - 1][column + 1];
            }
        }

        // current row
        if (column > 0)
        {
            surroundingCharacters[1][0] = array[row][column - 1];
        }
        if (column + 1 < array[row].Length)
        {
            surroundingCharacters[1][2] = array[row][column + 1];
        }

        // row below
        if (row + 1 < array.Length)
        {
            if (column > 0)
            {
                surroundingCharacters[2][0] = array[row + 1][column - 1];
            }
            
            surroundingCharacters[2][1] = array[row + 1][column];
            
            if (column + 1 < array[row + 1].Length)
            {
                surroundingCharacters[2][2] = array[row + 1][column + 1];
            }
        }

        return surroundingCharacters;
    }

    private static char[][] GetArray(IEnumerable<string> lines)
    {
        return lines.Select(line => line.ToCharArray()).ToArray();
    }
}