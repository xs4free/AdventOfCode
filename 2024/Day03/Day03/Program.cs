
using Day03;

var input = await File.ReadAllTextAsync(@"..\..\..\..\input.txt");

var instructions = InstructionParser.Parse(input).ToList();

var resultMulInstructions = InstructionExecuter.Execute(instructions.Where(instruction => instruction is MulInstruction));
Console.WriteLine($"Result of multiplications of only MulInstructions for input.text is: {resultMulInstructions}");

var resultAllInstructions = InstructionExecuter.Execute(instructions);
Console.WriteLine($"Result of multiplications for all instructions for input.text is: {resultAllInstructions}");