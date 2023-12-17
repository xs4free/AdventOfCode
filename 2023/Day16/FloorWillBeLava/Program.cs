using FloorWillBeLava;

const string inputFile = @"../../../../Input-Day16.txt";

var lines = await File.ReadAllLinesAsync(inputFile);

var tiles = EnergyCalculator.EnergizedTiles(lines);
Console.WriteLine($"Energized tiles: {tiles}");