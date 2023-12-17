using LensLibrary;

const string inputFile = @"../../../../Input-Day15.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var hash = Hash.Compute(lines[0]);
Console.WriteLine($"Hash: {hash}");