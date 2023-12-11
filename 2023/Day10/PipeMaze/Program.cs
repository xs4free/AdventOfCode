using PipeMaze;

const string inputFile = @"../../../../Input-Day10.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var steps = MazeFinder.StepsToFarthestPoint(lines);
Console.WriteLine($"Steps to farthest point: {steps}");