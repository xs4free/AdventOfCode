using Day15;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");

var (map1, moves1) = InputParser.ParseForPart1(input);
var newMap1 = RobotMover.Move(map1, moves1);
var sum1 = GpsScorer.Score(newMap1);
Console.WriteLine($"Sum of GPS coordinates for Input.txt using simple boxes is: {sum1}");

var (map2, moves2) = InputParser.ParseForPart2(input);
var newMap2 = RobotMover.Move(map2, moves2);
var sum2 = GpsScorer.Score(newMap2);
Console.WriteLine($"Sum of GPS coordinates for Input.txt using large boxes is: {sum2}");