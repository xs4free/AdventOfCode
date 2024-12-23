﻿using Day06;

var lines = await File.ReadAllLinesAsync(@"..\..\..\..\input.txt");
var input = InputParser.Parse(lines);

var uniquePositionsWalked = RouteCalculator.CountStepsFromStartToExit(input);
Console.WriteLine($"Walked {uniquePositionsWalked} to exit the map in file input.txt");

var endlessLoopPositions = RouteCalculator.GetPositionsForEndlessLoop(input).Count();
Console.WriteLine($"{endlessLoopPositions} positions found for an endless loop in file input.txt");