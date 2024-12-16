using Day14;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");

var mapSize = new MapSize(101, 103);
var robots = InputParser.Parse(input).ToList();
var newPositions = robots.Select(robot => RobotSimulator.Simulate(robot, 100, mapSize)).ToList();
var factor = SafetyFactorCalculator.Calculate(newPositions, mapSize); 

Console.WriteLine($"Safety factor for Input.txt is: {factor}.);
