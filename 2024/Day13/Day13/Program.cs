using Day13;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var machines = InputParser.Parse(input);

var tokens = machines.Sum(MachineSolver.CostOfCheapestSolution);
Console.WriteLine($"To solve al machines in Input.txt would cost {tokens} tokens.");