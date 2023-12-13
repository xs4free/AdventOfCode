using CosmicExpansion;

const string inputFile = @"../../../../Input-Day11.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sum = GalaxyMap.SumShortestPaths(lines);
Console.WriteLine($"Sum shortest paths: {sum}");