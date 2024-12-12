namespace Day11
{
    public static class InputParser
    {
        public static List<long> Parse(string input)
        {
            return input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse).ToList();
        }
    }
}
