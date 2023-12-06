namespace AlmanacReader;

internal class AlmanacParser
{
    public static Seeds? ReadMaps(IEnumerable<string> lines)
    {
        Seeds? seeds = null;
        Map? currentMap = null;
        
        foreach (var line in lines)
        {
            if (line.StartsWith("seeds:"))
            {
                var split = line.Split(new []{ ":"," " }, StringSplitOptions.RemoveEmptyEntries);
                seeds = new(split[1..].Select(long.Parse).ToList(), null);
                continue;
            }

            if (line.EndsWith("map:"))
            {
                (string source, string destination) = GetSourceDestination(line);
                var newMap = new Map(source, destination, null, new());

                if (seeds != null && seeds.Target == null)
                {
                    seeds.Target = newMap;
                }
                else if (currentMap != null)
                {
                    currentMap.Target = newMap;
                }

                currentMap = newMap;
                continue;
            }

            if (line == String.Empty)
            {
                continue;
            }

            if (currentMap != null)
            {
                var translations = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                currentMap.Translations.Add(CreateTranslation(translations));
            }
        }

        return seeds;
    }

    private static (string source, string destination) GetSourceDestination(string line)
    {
        var split = line.Split(new []{"-", " "}, StringSplitOptions.RemoveEmptyEntries);
        return (split[0], split[2]);
    }

    private static Translation CreateTranslation(IReadOnlyList<long> translations) =>
        new(new NumberRange(translations[1], translations[1] + translations[2] - 1),
            new NumberRange(translations[0],translations[0] + translations[2] - 1));    
}