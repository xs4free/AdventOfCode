using ParabolicReflectorDish;

const string inputFile = @"../../../../Input-Day14.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var load = LoadCalculator.Calculate(lines);
Console.WriteLine($"Load on north support beams: {load}");
