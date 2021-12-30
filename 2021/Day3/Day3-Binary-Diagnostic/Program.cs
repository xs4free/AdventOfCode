using Day3_Binary_Diagnostic;

string[] report = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt", System.Text.Encoding.UTF8);
Console.WriteLine($"Report lines: {report.Length}");

DiagnosticReportAnalyzer analyzer = new();
var result = analyzer.Analyze(report);

Console.WriteLine($"Gamma rate: {result.GammaRate}");
Console.WriteLine($"Epsilon rate: {result.EpsilonRate}");
Console.WriteLine($"Power consumption: {result.PowerConsumption}");
Console.WriteLine();
Console.WriteLine($"Oxygen generator rating: {result.OxygenGeneratorRating}");
Console.WriteLine($"CO2 scrubber rating: {result.CO2ScrubberRating}");
Console.WriteLine($"Life support rating: {result.LifeSupportRating}");
