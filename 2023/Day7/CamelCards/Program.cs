using CamelCards;

const string inputFile = @"../../../../Input-Day7.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var totalWinningsPart1 = CamelCardCalculator.TotalWinningsPart1(lines);
Console.WriteLine($"Total winnings part 1: {totalWinningsPart1}");

var totalWinningsPart2 = CamelCardCalculator.TotalWinningsPart2(lines);
Console.WriteLine($"Total winnings part 2: {totalWinningsPart2}");