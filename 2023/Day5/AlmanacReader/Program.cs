using AlmanacReader;

const string inputFile = @"../../../../Input-Day5.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var lowestLocation = AlmanacParser.FindLowestLocation(lines);
Console.WriteLine($"Lowest location: {lowestLocation}");