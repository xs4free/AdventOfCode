namespace AlmanacReader;

internal static class NumberRangeExtensions
{
    /// <summary>
    /// range 1: { 1 2 3 4 5 }
    /// range 2: { 2 3 } { 4 }
    /// result: { 1 } { 5 }
    ///
    /// range 1: { 4 5 }
    /// range 2: { 2 3 }
    /// result: { 4 5 }
    /// </summary>
    public static List<NumberRange> Except(this List<NumberRange> range1, List<NumberRange> range2)
    {
        var result = new List<NumberRange>();

        var orderedRange1 = range1.OrderBy(range => range.Begin).ToList();
        var orderedRange2 = range2.OrderBy(range => range.Begin).ToList();

        var range1Combined = new NumberRange(orderedRange1.First().Begin, orderedRange1.Last().End);
        var range2Combined = new NumberRange(orderedRange2.First().Begin, orderedRange2.Last().End);
        
        // range 1 before range 2
        if (range1Combined.Begin < range2Combined.Begin)
        {
            result.Add(new NumberRange(range1Combined.Begin, Math.Min(range1Combined.End, range2Combined.Begin - 1)));
        }
        
        // range 1 after range 2
        if (range1Combined.End > range2Combined.End)
        {
            result.Add(new NumberRange(Math.Max(range1Combined.Begin, range2Combined.End + 1), range1Combined.End));
        }
        
        return result;
    }

    public static NumberRange? Intersect(this NumberRange range1, NumberRange range2)
    {
        // range 1 is bigger than range 2
        if (range1.Begin <= range2.Begin && range1.End >= range2.End)
        {
            return range2;
        }
        
        // range 1 begins inside range 2
        if (range1.Begin >= range2.Begin && range1.Begin <= range2.End)
        {
            return new (range1.Begin, Math.Min(range1.End, range2.End));
        }
        
        // range 1 ends inside range 2
        if (range1.End >= range2.Begin && range1.End <= range2.End)
        {
            return new (range2.Begin, range1.End);
        }

        return null;
    }

}