using ParabolicReflectorDish;

const string inputFile = @"../../../../Input-Day14.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var load = LoadCalculator.Calculate(lines);
Console.WriteLine($"Load on north support beams: {load}");

var loadWithCycles = LoadCalculator.CalculateWithCycles(lines, 1000000000);
Console.WriteLine($"Load on north support beams after 1000000000 cycles: {loadWithCycles}");

