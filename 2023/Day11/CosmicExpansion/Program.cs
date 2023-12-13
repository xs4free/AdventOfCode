using CosmicExpansion;

const string inputFile = @"../../../../Input-Day11.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sum1 = GalaxyMap.SumShortestPaths(lines, 2);
Console.WriteLine($"Sum shortest paths (2 times expansion): {sum1}");

var sum2 = GalaxyMap.SumShortestPaths(lines, 1000000);
Console.WriteLine($"Sum shortest paths (1.000.000 expansion): {sum2}");