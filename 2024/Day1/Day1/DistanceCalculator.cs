namespace Day1;

public static class DistanceCalculator
{
    public static int Calculate(IEnumerable<int> list1, IEnumerable<int> list2)
    {
        var sortedList1 = list1.OrderBy(x => x).ToList();
        var sortedList2 = list2.OrderBy(x => x).ToList();

        return sortedList1.Select((t, i) => Math.Abs(t - sortedList2[i])).Sum();
    }
}