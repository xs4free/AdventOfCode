namespace Day09;

public static class InputParser
{
    public static Diskmap Parse(string input)
    {
        var fileId = 0;
        var result = new Diskmap();

        for (var inputIndex = 0; inputIndex < input.Length; inputIndex++)
        {
            var sectorSize = input[inputIndex] - 48; // convert to int

            var sectorType = inputIndex % 2 == 0 ? SectorType.File : SectorType.Empty;
            var currentFileId = sectorType == SectorType.File ? fileId++ : (int?)null; 
            
            for (var sectorIndex = 0; sectorIndex < sectorSize; sectorIndex++)
            {
                result.Sectors.Add(new Sector(sectorType, currentFileId));
            }
        }
        
        return result;
    }
}