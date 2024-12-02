using Day02;

var lines = await File.ReadAllLinesAsync("..\\..\\..\\..\\input.txt");
var reports = InputParser.Parse(lines);

var safeReportCountWithoutDampening = reports.Count(report => SafetyEvaluator.IsSafe(report, useDampening: false));
Console.WriteLine($"Total safe reports for input.txt without dampening: {safeReportCountWithoutDampening}");

var safeReportCountWitDampening = reports.Count(report => SafetyEvaluator.IsSafe(report, useDampening: true));
Console.WriteLine($"Total safe reports for input.txt with dampening: {safeReportCountWitDampening}");

