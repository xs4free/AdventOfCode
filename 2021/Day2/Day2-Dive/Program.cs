using Day2_Dive;

string[] lines = await File.ReadAllLinesAsync(@"..\..\..\Input.txt", System.Text.Encoding.UTF8);

PositionTracker tracker = new();
InputProcessor processor = new(tracker);

processor.ProcessLines(lines);

Console.WriteLine($"Steps: {lines.Count()}");
Console.WriteLine($"Horizontal position: {tracker.HorizontalPostion}");
Console.WriteLine($"Depth: {tracker.Depth}");
Console.WriteLine();
Console.WriteLine($"Answer: {tracker.HorizontalPostion * tracker.Depth}");
