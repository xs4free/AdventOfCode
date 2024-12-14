using Day10;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(lines);

var trailEnds = MapAnalyzer.CountTrailEnds(map, true);
Console.WriteLine($"There are {trailEnds} trail ends in input.txt");

var allRoutes = MapAnalyzer.CountTrailEnds(map, false);
Console.WriteLine($"There are {allRoutes} trails in input.txt");