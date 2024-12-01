namespace Day1;

public static class SimilarityCalculator
{
    public static int Calculate(IEnumerable<int> list1, IEnumerable<int> list2)
    {
        var grouped = list2.GroupBy(x => x);
        var hashedList2 = grouped.ToDictionary(x => x.Key, x => x.Count());

        return list1
            .Where(item => hashedList2.ContainsKey(item))
            .Sum(item => item * hashedList2[item]);
    }
}