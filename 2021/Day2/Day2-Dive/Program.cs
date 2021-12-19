using Day2_Dive;

string[] lines = await File.ReadAllLinesAsync(@"..\..\..\Input.txt", System.Text.Encoding.UTF8);
Console.WriteLine($"Steps: {lines.Count()}");

IPositionTracker trackerPart1 = new PositionTrackerPart1();
IPositionTracker trackerPart2 = new PositionTrackerPart2();

Process(lines, trackerPart1);
Process(lines, trackerPart2);

void Process(string[] lines, IPositionTracker tracker)
{
    InputProcessor processor = new(tracker);

    processor.ProcessLines(lines);

    Console.WriteLine($"Tracker: {tracker.GetType().Name}");
    Console.WriteLine($"Horizontal position: {tracker.HorizontalPostion}");
    Console.WriteLine($"Depth: {tracker.Depth}");
    Console.WriteLine($"Answer: {tracker.HorizontalPostion * tracker.Depth}");
    Console.WriteLine();
}
