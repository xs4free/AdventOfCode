using CubeConundrum;

const string inputFile = @"../../../../Input-Day2.txt";
const string bagContentsInput = "12 red, 13 green, 14 blue";

await OutputConundrumSolver(inputFile);
return;

async Task OutputConundrumSolver(string filename)
{
    var lines = await File.ReadAllLinesAsync(filename);
    var sum = CubeConundrumSolver.GetSumOfPossibleGameIds(bagContentsInput, lines);
    
    Console.WriteLine($"Sum: {sum}");
}