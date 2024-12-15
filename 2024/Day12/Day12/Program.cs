using Day12;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(input);

var perimeterPrice = FencePriceCalculator.CalculatePerimeter(map);
Console.WriteLine($"Fences around perimeter of Input.txt cost {perimeterPrice}");

var sidesPrice = FencePriceCalculator.CalculateSides(map);
Console.WriteLine($"Fences around sides of Input.txt cost {sidesPrice}");