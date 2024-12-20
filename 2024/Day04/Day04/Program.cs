﻿
using Day04;

var input = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var map = InputParser.Parse(input);

const string wordToFind = "XMAS";
var matchCount = WordFinder.Count(wordToFind, map);
Console.WriteLine($"Found '{wordToFind}' {matchCount} times in input file.");

const string wordToFindInX = "MAS";
var matchCountX = WordFinder.CountX(wordToFindInX, map);
Console.WriteLine($"Found '{wordToFindInX}' {matchCountX} times in input file.");
