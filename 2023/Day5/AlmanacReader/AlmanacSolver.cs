namespace AlmanacReader;

public static class AlmanacSolver
{
    public static long FindLowestLocationSingleSeeds(IEnumerable<string> lines)
    {
        var seeds = AlmanacParser.ReadMaps(lines);

        var seedLocations = seeds?.Numbers.Select(seed => TranslateSourceToDestination(seeds?.Target, seed)).ToList();
        
        return seedLocations?.Min() ?? 0;
    }

    public static long FindLowestLocationRangedSeeds(IEnumerable<string> lines)
    {
        var seeds = AlmanacParser.ReadMaps(lines);
        var seedNumbers = GetSeedRanges(seeds);

        var seedLocations = seedNumbers.SelectMany(seedRange => TranslateSourceToDestination(seeds?.Target, new List<NumberRange> { seedRange })).ToList();
        
        return seedLocations.Min(location => location.Begin);
    }

    private static List<NumberRange> GetSeedRanges(Seeds? seeds)
    {
        ArgumentNullException.ThrowIfNull(seeds);
        
        var seedRanges = new List<NumberRange>();
        
        for (var index = 0; index < seeds.Numbers.Count; index += 2)
        {
            var first = seeds.Numbers[index];
            var last = first + seeds.Numbers[index + 1] - 1;
            
            seedRanges.Add(new (first, last));
        }

        return seedRanges;
    }

    private static long TranslateSourceToDestination(Map? map, long source)
    {
        ArgumentNullException.ThrowIfNull(map);
        
        var translatedValue = source;

        foreach (var translation in map.Translations.Where(translation =>
                     translation.Source.Begin <= source && translation.Source.End >= source))
        {
            translatedValue = translation.Destination.Begin + (source - translation.Source.Begin);
            break;
        }

        return map?.Target == null ? translatedValue : TranslateSourceToDestination(map.Target, translatedValue);
    }

    private static IEnumerable<NumberRange> TranslateSourceToDestination(Map? map, List<NumberRange> sources)
    {
        ArgumentNullException.ThrowIfNull(map);
        
        var mappedRanges = MapRanges(map, sources);

        var rangesNotMapped = sources.ToList().Except(
            map.Translations.Select(translations => translations.Source).ToList());
        mappedRanges.AddRange(rangesNotMapped);        

        return map.Target == null ? mappedRanges : TranslateSourceToDestination(map.Target, mappedRanges);
    }

    private static List<NumberRange> MapRanges(Map map, List<NumberRange> sources)
    {
        List<NumberRange> mappedRanges = new();

        foreach (var translation in map.Translations)
        {
            foreach (var source in sources)
            {
                var intersect = translation.Source.Intersect(source);
                if (intersect != null)
                {
                    var sourceBeginDiff = translation.Source.End - intersect.Begin;
                    var sourceEndDiff = translation.Source.End - intersect.End;
                    
                    mappedRanges.Add(new NumberRange(
                        translation.Destination.End - sourceBeginDiff,
                        translation.Destination.End - sourceEndDiff));
                }
            }
        }

        return mappedRanges;
    }
}