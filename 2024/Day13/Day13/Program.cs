using Day13;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");

var machinesNoOffset = InputParser.Parse(input, 0).ToList();
var tokensNoOffset = machinesNoOffset.Sum(MachineSolver.CostOfCheapestSolution);
Console.WriteLine($"To solve all machines in Input.txt without an offset would cost {tokensNoOffset} tokens.");

var machinesWithOffset = InputParser.Parse(input, 10000000000000).ToList();
var tokensWithOffset = machinesWithOffset.Sum(MachineSolver.CostOfCheapestSolution);
Console.WriteLine($"To solve all machines in Input.txt with an offset would cost {tokensWithOffset} tokens.");
