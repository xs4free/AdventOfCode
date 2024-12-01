// See https://aka.ms/new-console-template for more information

using Day1;

var lines = await File.ReadAllLinesAsync("..\\..\\..\\..\\input.txt");
var (l1, l2) = InputParser.Parse(lines);
var totalDistance = DistanceCalculator.Calculate(l1, l2);

Console.WriteLine($"Total distance for input.txt is: {totalDistance}");