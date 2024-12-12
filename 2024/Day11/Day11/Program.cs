using Day11;

var input = File.ReadAllText(@"..\..\..\..\input.txt");
var stones = InputParser.Parse(input);

var blinkedStones = StoneBlinker.Blink(stones, 25);
Console.WriteLine($"Input.txt blinked 25 times results in {blinkedStones.Count} stones");

var blinkedStones75 = StoneBlinker.BlinkCount(stones, 75);
Console.WriteLine($"Input.txt blinked 75 times results in {blinkedStones75} stones");