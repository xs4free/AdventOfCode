
using Day04;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(input);
const string wordToFind = "XMAS";
var matchCount = WordFinder.Count(wordToFind, map);

Console.WriteLine($"Found '{wordToFind}' {matchCount} times in input file.");
