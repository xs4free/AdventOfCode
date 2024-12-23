using Day15;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");

var (map, moves) = InputParser.Parse(input);
var newMap = RobotMover.Move(map, moves);

var sum = GpsScorer.Score(newMap);

Console.WriteLine($"Sum of GPS coordinates for Input.txt is: {sum}");