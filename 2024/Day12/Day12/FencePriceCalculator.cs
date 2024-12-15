namespace Day12;

public static class FencePriceCalculator
{
    public static int Calculate(char[][] map)
    {
        var price = 0;
        
        var areas = AreaFinder.Find(map);
        foreach (var area in areas)
        {
            var fences = FenceLocator.Locate(area);
            price += fences.Count() * area.Positions.Count();
        }
        
        return price;
    }
}