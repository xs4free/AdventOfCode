using PointOfIncidence;

const string inputFile = @"../../../../Input-Day13.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sum = MirrorFinder.SummarizeAllNotes(lines, repairSmudge: false);
Console.WriteLine($"Sum of notes: {sum}");

var sumRepaired = MirrorFinder.SummarizeAllNotes(lines, repairSmudge: true);
Console.WriteLine($"Sum of notes with smudged repaired: {sumRepaired}");