using Day1_SonarSweep;
using System.Text;

string[] lines = await File.ReadAllLinesAsync(@"..\..\..\input.txt", Encoding.UTF8);
int[] depths = lines.Select(line => Convert.ToInt32(line)).ToArray();

var sonar = new Sonar();
var report = sonar.CreateReport(depths);

foreach(var line in report.Output)
{
    Console.WriteLine(line);
}

Console.WriteLine("---------------");
Console.WriteLine($"Lines: {report.Lines}");
Console.WriteLine($"Increases: {report.Increases}");
Console.WriteLine($"Decreases: {report.Decreases}");
Console.WriteLine("---------------");
