using Day08;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(lines);

var antiNodeLocations = AntinodeLocator.Locate(map, false);
Console.WriteLine($"Unique location for antinodes in input.txt is: {antiNodeLocations.Count()}");

var antiNodeRepeatedLocations = AntinodeLocator.Locate(map, true);
Console.WriteLine($"Unique location for antinodes with repetition in input.txt is: {antiNodeRepeatedLocations.Count()}");