namespace Day09;

public static class Filesystem
{
    public static long Checksum(Diskmap input)
    {
        var checksum = 0L;
        
        for (var i = 0; i < input.Sectors.Count; i++)
        {
            var fileId = input.Sectors[i].FileId ?? 0;
            checksum += i * fileId;    
        }
        
        return checksum;
    }
}