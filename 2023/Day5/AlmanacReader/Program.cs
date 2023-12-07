using AlmanacReader;

const string inputFile = @"../../../../Input-Day5.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var lowestLocationSingle = AlmanacSolver.FindLowestLocationSingleSeeds(lines);
Console.WriteLine($"Lowest location single seeds: {lowestLocationSingle}");

var lowestLocationRanged = AlmanacSolver.FindLowestLocationRangedSeeds(lines);
Console.WriteLine($"Lowest location ranged seeds: {lowestLocationRanged}");