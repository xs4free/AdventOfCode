using GearRatios;

const string inputFile = @"../../../../Input-Day3.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sumOfPartNumbers = EngineSchematicAnalyzer.SumOfPartNumbers(lines);
Console.WriteLine($"Sum of partnumbers: {sumOfPartNumbers}");

var sumOfGearRatios = EngineSchematicAnalyzer.SumOfGearRatios(lines);
Console.WriteLine($"Sum of gear ratios: {sumOfGearRatios}");

