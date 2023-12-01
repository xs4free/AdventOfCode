using Trebuchet;

const string inputFile = @"../../../../Input-Day1.txt";

await OutputParseCalibrationFile(inputFile, 1, CalibrationParserMode.Digits);
await OutputParseCalibrationFile(inputFile, 2, CalibrationParserMode.DigitsAndWords);

async Task OutputParseCalibrationFile(string filename, int part, CalibrationParserMode mode)
{
    var lines = await File.ReadAllLinesAsync(filename);
    var calibrationNumber = CalibrationParser.Parse(lines, mode);
    Console.WriteLine($"Part {part} - {calibrationNumber}");
}