using HotSprings;

const string inputFile = @"../../../../Input-Day12.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sumFolded = SpringReport.SumOfArrangements(lines, 1);
Console.WriteLine($"Sum of arrangements folded: {sumFolded}");

var sumUnfolded = SpringReport.SumOfArrangements(lines, 5);
Console.WriteLine($"Sum of arrangements unfolded: {sumUnfolded}");