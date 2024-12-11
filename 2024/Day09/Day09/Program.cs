using Day09;

var line = File.ReadAllText(@"..\..\..\..\input.txt");
var map = InputParser.Parse(line);

var defraggedSectorsMap = Defragger.DefragSectors(map);
var checksumSectors = Filesystem.Checksum(defraggedSectorsMap);
Console.WriteLine($"Checksum for defragged sectors input.txt is: {checksumSectors}");


var defraggedFilesMap = Defragger.DefragFiles(map);
var checksumFiles = Filesystem.Checksum(defraggedFilesMap);
Console.WriteLine($"Checksum for defragged files input.txt is: {checksumFiles}");
