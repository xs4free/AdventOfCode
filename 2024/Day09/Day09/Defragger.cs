namespace Day09;

public static class Defragger
{
    public static Diskmap DefragSectors(Diskmap map)
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

    public static Diskmap DefragFiles(Diskmap map)
    {
        var result = CloneDiskmap(map);
        var spaces = GetSpaces(result).ToList();

        for (var spaceIndex = spaces.Count - 1; spaceIndex >= 0; spaceIndex--)
        {
            var fileSpace = spaces[spaceIndex];
            
            if (fileSpace.SectorType == SectorType.File)
            {
                var emptyIndex = spaces.FindIndex(emptySpace =>
                    emptySpace.SectorType == SectorType.Empty && emptySpace.SectorCount >= fileSpace.SectorCount &&
                    emptySpace.SectorStartIndex < fileSpace.SectorStartIndex);

                if (emptyIndex >= 0)
                {
                    spaceIndex += SwapSpacesAndMap(spaces, emptyIndex, spaceIndex);
                }
            }
        }

        result.Sectors = RegenerateSectorsBasedOnSpace(spaces);
        return result;
    }

    private static List<Sector> RegenerateSectorsBasedOnSpace(List<Space> spaces)
    {
        var result = new List<Sector>();
        
        foreach (var space in spaces)
        {
            for (var i = 0; i < space.SectorCount; i++)
            {
                result.Add(new Sector(space.SectorType, space.FileId));
            }
        }

        return result;
    }

    private static int SwapSpacesAndMap(List<Space> spaces, int emptyIndex, int fileIndex)
    {
        var emptySpace = spaces[emptyIndex];
        var fileSpace = spaces[fileIndex];
        
        spaces[fileIndex] = fileSpace with { SectorType = SectorType.Empty, FileId = null };
        spaces[emptyIndex] = emptySpace with { SectorType = SectorType.File, FileId = fileSpace.FileId, SectorCount = fileSpace.SectorCount };
        if (emptySpace.SectorCount > fileSpace.SectorCount)
        {
            // add new empty space after moved file
            spaces.Insert(emptyIndex + 1, new Space(SectorType.Empty, null, emptySpace.SectorStartIndex + fileSpace.SectorCount, emptySpace.SectorCount - fileSpace.SectorCount));
            return 1;
        }

        return 0;
    }

    private static Diskmap CloneDiskmap(Diskmap map) => new() { Sectors = new List<Sector>(map.Sectors) };

    private static IEnumerable<Space> GetSpaces(Diskmap map)
    {
        for (var i = 0; i < map.Sectors.Count; i++)
        {
            var size = GetSpaceSize(i, map.Sectors);

            yield return new Space(map.Sectors[i].SectorType, map.Sectors[i].FileId, i, size);

            i += size - 1;
        }
    }

    private static int GetSpaceSize(int startIndex, List<Sector> sectors)
    {
        var size = 1;
        
        var startType = sectors[startIndex].SectorType;
        var startFileId = sectors[startIndex].FileId;
        
        for (var i = startIndex + 1; i < sectors.Count; i++)
        {
            if (sectors[i].SectorType != startType
                || sectors[i].FileId != startFileId)
            {
                break;
            }

            size++;
        }

        return size;
    }
}