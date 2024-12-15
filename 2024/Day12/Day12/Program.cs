using Day12;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(input);

var price = FencePriceCalculator.Calculate(map);
Console.WriteLine($"Fences around Input.txt cost {price}");