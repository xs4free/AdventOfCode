using Scratchcards;

const string inputFile = @"../../../../Input-Day4.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var totalScore = ScoreCalculator.ScoreCards(lines);
Console.WriteLine($"Total score: {totalScore}");