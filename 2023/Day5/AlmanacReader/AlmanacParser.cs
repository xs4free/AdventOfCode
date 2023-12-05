namespace AlmanacReader;

public static class AlmanacParser
{
    public static long FindLowestLocation(IEnumerable<string> lines)
    {
        var seeds = ReadMaps(lines);

        var seedLocations = seeds.Numbers.Select(seed => Translate(seeds.Target, seed)).ToList();
        
        return seedLocations.Min();
    }

    private static long Translate(Map map, long source)
    {
        var translatedValue = source;
        
        foreach (var translation in map.Translations)
        {
            if (translation.SourceStart <= source && translation.SourceEnd >= source)
            {
                translatedValue = translation.DestinationStart + (source - translation.SourceStart);
                break;
            }
        }

        return map.Target == null ? translatedValue : Translate(map.Target, translatedValue);
    }
    
    private static Seeds ReadMaps(IEnumerable<string> lines)
    {
        Seeds seeds = null;
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

                if (seeds.Target == null)
                {
                    seeds.Target = newMap;
                }
                else
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
            
            var translations = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            currentMap.Translations.Add(CreateTranslation(translations));
        }

        return seeds;
    }

    private static (string source, string destination) GetSourceDestination(string line)
    {
        var split = line.Split(new []{"-", " "}, StringSplitOptions.RemoveEmptyEntries);
        return (split[0], split[2]);
    }

    private static Translation CreateTranslation(IReadOnlyList<long> translations) =>
        new(translations[1], 
            translations[1] + translations[2] - 1,
            translations[0], 
            translations[0] + translations[2] - 1);
}