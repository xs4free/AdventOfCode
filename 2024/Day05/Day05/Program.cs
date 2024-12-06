using Day05;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var input = InputParser.Parse(lines);
var validUpdates = UpdateValidator.GetValidUpdates(input);
var score = ValidUpdateScore.Score(validUpdates);

Console.WriteLine($"Score of valid update for input.txt is: {score}");