using HotSprings;

const string inputFile = @"../../../../Input-Day12.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sum = SpringReport.SumOfArrangements(lines);
Console.WriteLine($"Sum of arrangements: {sum}");