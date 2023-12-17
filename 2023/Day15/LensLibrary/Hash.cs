namespace LensLibrary;

public static class Hash
{
    public static long Compute(string line)
    {
        var split = line.Contains(',') ? line.Split(',', StringSplitOptions.RemoveEmptyEntries) : new [] { line };
        
        return split.Select(ComputeInternal).Sum();
    }

    private static long ComputeInternal(string value)
    {
        var result = 0;
        
        foreach(var chr in value)
        {
            result += chr;
            result *= 17;
            result %= 256;
        }

        return result;
    }
}