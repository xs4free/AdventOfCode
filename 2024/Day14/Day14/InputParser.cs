namespace Day14;

public static class InputParser
{
    public static IEnumerable<Robot> Parse(string[] input)
    {
        foreach (var line in input)
        {
            var split = line.Split(['=', ',', ' '], StringSplitOptions.RemoveEmptyEntries);

            var pX = int.Parse(split[1]);
            var pY = int.Parse(split[2]);
            var vX = int.Parse(split[4]);
            var vY = int.Parse(split[5]);
            
            yield return new Robot(new (pX, pY), new (vX, vY));
        }
    }
}