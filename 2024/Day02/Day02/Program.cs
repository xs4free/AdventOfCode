using Day02;

var lines = await File.ReadAllLinesAsync("..\\..\\..\\..\\input.txt");
var reports = InputParser.Parse(lines);

var safeReportCount = reports.Count(SafetyEvaluator.IsSafe);
Console.WriteLine($"Total safe reports for input.txt is: {safeReportCount}");

