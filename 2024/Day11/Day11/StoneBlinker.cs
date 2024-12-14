﻿
namespace Day11
{
    public static class StoneBlinker
    {
        public static List<long> Blink(List<long> input, int blinkCount)
        {
            var result = new List<long>(input);

            for (var blink = 0; blink < blinkCount; blink++)
            {
                BlinkOnce(result);
            }

            return result;
        }
        public static long BlinkCount(List<long> input, int blinkCount)
        {
            long result = 0;

            foreach (var number in input)
            {
                result += BlinkRecursive(number, blinkCount);
            }

            return result;
        }

        private static Dictionary<(long,int), long> _blinkCache = new();

        private static long BlinkRecursive(long input, int blinkCount)
        {
            if (blinkCount == 0)
            {
                return 1;
            }

            var cacheKey = (input, blinkCount);
            if (_blinkCache.TryGetValue(cacheKey, out var cachedResult))
            {
                return cachedResult;
            }

            if (input == 0)
            {
                var result0 = BlinkRecursive(1, --blinkCount);
                _blinkCache.Add(cacheKey, result0);
                return result0;
            }

            var number = input.ToString();
            if (number.Length % 2 == 0)
            {
                var n1 = long.Parse(number[..(number.Length / 2)]);
                var n2 = long.Parse(number[(number.Length / 2)..]);

                var resultSplit = 0L;
                resultSplit += BlinkRecursive(n1, blinkCount - 1);
                resultSplit += BlinkRecursive(n2, blinkCount - 1);

                _blinkCache.Add(cacheKey, resultSplit);
                return resultSplit;
            }

            var result = BlinkRecursive(input * 2024, --blinkCount);
            _blinkCache.Add(cacheKey, result);
            return result;
        }

        private static void BlinkOnce(List<long> input)
        {
            var originalCount = input.Count;
            for (var i = 0; i < originalCount; i++)
            {
                if (input[i] == 0)
                {
                    input[i] = 1;
                    continue;
                }

                var number = input[i].ToString();
                if (number.Length % 2 == 0)
                {
                    var n1 = long.Parse(number[..(number.Length / 2)]);
                    var n2 = long.Parse(number[(number.Length / 2)..]);

                    input[i] = n1;
                    input.Add(n2);

                    continue;
                }

                input[i] *= 2024;
            }
        }
    }
}