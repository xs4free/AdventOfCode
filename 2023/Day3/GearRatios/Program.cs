using GearRatios;

const string inputFile = @"../../../../Input-Day3.txt";

var lines = await File.ReadAllLinesAsync(inputFile);
var sum = EngineSchematicAnalyzer.SumOfPartNumbers(lines);
    
Console.WriteLine($"Sum: {sum}");
