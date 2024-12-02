using Day01;

var lines = await File.ReadAllLinesAsync("..\\..\\..\\..\\input.txt");
var (l1, l2) = InputParser.Parse(lines);

var totalDistance = DistanceCalculator.Calculate(l1, l2);
Console.WriteLine($"Total distance for input.txt is: {totalDistance}");

var similarityScore = SimilarityCalculator.Calculate(l1, l2);
Console.WriteLine($"Similarity score for input.txt is: {similarityScore}");

