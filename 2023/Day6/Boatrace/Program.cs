using Boatrace;

const string inputFile = @"../../../../Input-Day6.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var margin = RaceCalculator.CalculateMargin(lines);
Console.WriteLine($"Margin: {margin}");