using Day09;

var line = File.ReadAllText(@"..\..\..\..\input.txt");
var map = InputParser.Parse(line);

var defraggedMap = Defragger.Defrag(map);

var checksum = Filesystem.Checksum(defraggedMap);
Console.WriteLine($"Checksum for defragged input.txt is: {checksum}");
