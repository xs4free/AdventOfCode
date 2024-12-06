
using Day03;

var input = await File.ReadAllTextAsync("..\\..\\..\\..\\input.txt");

var instructions = MulParser.Parse(input);
var result = instructions.Select(MulExecuter.Execute).Sum();

Console.WriteLine($"Result of multiplications for input.text is: {result}");