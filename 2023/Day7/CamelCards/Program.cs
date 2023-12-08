using CamelCards;

const string inputFile = @"../../../../Input-Day7.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var totalWinnings = CamelCardCalculator.TotalWinnings(lines);
Console.WriteLine($"Total winnings: {totalWinnings}");