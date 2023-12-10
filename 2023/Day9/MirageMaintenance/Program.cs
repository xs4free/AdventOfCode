using MirageMaintenance;

const string inputFile = @"../../../../Input-Day9.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var sum = Oasis.PredictAll(lines);
Console.WriteLine($"Sum: {sum}");