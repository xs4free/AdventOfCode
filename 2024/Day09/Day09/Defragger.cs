namespace Day09;

public static class Defragger
{
    public static Diskmap Defrag(Diskmap map)
    {
        var result = new Diskmap();

        var beginIndex = 0;
        var endIndex = map.Sectors.Count - 1;

        while (beginIndex < endIndex)
        {
            var frontSector = map.Sectors[beginIndex];
            
            // find empty spot at the front
            if (frontSector.SectorType == SectorType.File)
            {
                result.Sectors.Add(frontSector);
                beginIndex++;
                continue;
            }
            
            // find file at the end
            var backSector = map.Sectors[endIndex];
            if (backSector.SectorType == SectorType.Empty)
            {
                endIndex--;
                continue;
            }
            
            // swap file from back to front
            result.Sectors.Add(backSector);
            beginIndex++;
            endIndex--;
        }

        // add the current file sector if the last iteration of the loop was a swap
        if (map.Sectors[beginIndex].SectorType == SectorType.File &&
            beginIndex == endIndex)
        {
            result.Sectors.Add(map.Sectors[beginIndex]);
        }
        
        // add empty sectors to the end
        for (var i = result.Sectors.Count; i < map.Sectors.Count; i++)
        {
            result.Sectors.Add(new Sector(SectorType.Empty, null));
        }
        
        return result;
    }
}