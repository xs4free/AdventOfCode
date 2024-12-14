using Day10;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(lines);

var trailEnds = MapAnalyzer.CountTrailEnds(map);
Console.WriteLine($"There are {trailEnds} trail ends in input.txt");