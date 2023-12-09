using HauntedWasteland;

const string inputFile = @"../../../../Input-Day8.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var stepsTo = MapSolver.StepsTo(lines);
Console.WriteLine($"Steps to: {stepsTo}");