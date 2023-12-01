// See https://aka.ms/new-console-template for more information

using Trebuchet;

const string inputFile = @"../../../../Input-Day1.txt";
var lines = await File.ReadAllLinesAsync(inputFile);

var calibrationNumber = CalibrationParser.Parse(lines);
Console.WriteLine(calibrationNumber);
