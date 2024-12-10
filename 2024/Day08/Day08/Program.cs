using Day08;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(lines);

var antiNodeLocations = AntinodeLocator.Locate(map);
Console.WriteLine($"Unique location for antinodes in input.txt is: {antiNodeLocations.Count()}");