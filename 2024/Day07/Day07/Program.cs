using Day07;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var equations = InputParser.ParseInput(lines).ToList();

var score1 = Score.Calculate(equations, [Operator.Add, Operator.Multiply]);
Console.WriteLine($"Score for valid equations in input.txt with add and multiply operator is: {score1}");

var score2 = Score.Calculate(equations, [Operator.Add, Operator.Multiply, Operator.Concatenation]);
Console.WriteLine($"Score for valid equations in input.txt with all operators is: {score2}");