using MirageMaintenance;

const string inputFile = @"../../../../Input-Day9.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sumNext = Oasis.PredictAllValues(lines, PredictDirection.Next);
Console.WriteLine($"Sum next values: {sumNext}");

var sumPrevious = Oasis.PredictAllValues(lines, PredictDirection.Previous);
Console.WriteLine($"Sum previous values: {sumPrevious}");