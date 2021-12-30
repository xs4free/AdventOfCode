using Day3_Binary_Diagnostic;

string[] report = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt", System.Text.Encoding.UTF8);
Console.WriteLine($"Report lines: {report.Length}");

DiagnosticReportAnalyzer analyzer = new();
var result = analyzer.Analyze(report);

Console.WriteLine($"Gamma rate: {result.GammaRate}");
Console.WriteLine($"Epsilon rate: {result.EpsilonRate}");
Console.WriteLine($"Power consumption: {result.PowerConsumption}");
