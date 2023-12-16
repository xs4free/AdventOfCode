using PointOfIncidence;

const string inputFile = @"../../../../Input-Day13.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sum = MirrorFinder.SummarizeAllNotes(lines);
Console.WriteLine($"Sum of notes: {sum}");