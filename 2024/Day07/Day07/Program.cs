using Day07;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var equations = InputParser.ParseInput(lines);

var score = Score.Calculate(equations);

Console.WriteLine($"Score for valid equations in input.txt is: {score}");