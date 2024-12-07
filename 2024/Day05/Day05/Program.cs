using Day05;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var input = InputParser.Parse(lines);

var validUpdates = input.Updates.Where(update => UpdateValidator.IsValid(update, input.OrderingRules));
var score = ValidUpdateScore.Score(validUpdates);
Console.WriteLine($"Score of valid update for input.txt is: {score}");

var invalidUpdates = input.Updates.Where(update => !UpdateValidator.IsValid(update, input.OrderingRules)).ToList();
var fixedUpdates = invalidUpdates.Select(invalidUpdate => UpdateValidator.Fix(invalidUpdate, input.OrderingRules)).ToList();
var fixedScore = ValidUpdateScore.Score(fixedUpdates);
Console.WriteLine($"Score of fixed invalid updates for input.txt is: {fixedScore}");