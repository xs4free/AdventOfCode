namespace Boatrace
{
    public static class RaceCalculator
    {
        /// <summary>
        /// Time:      7  15   30
        /// Distance:  9  40  200                
        /// </summary>
        public static int CalculateMargin(IEnumerable<string> input)
        {
            var races = RaceReader.GetRaces(input).ToList();
            var winningRaceCombinations = races.Select(race => GetWinningRaceOptions(race).Count()).ToList(); 
            
            var power = winningRaceCombinations.First();

            return winningRaceCombinations.Skip(1).Aggregate(power, (current, combination) => current * combination);
        }

        public static long CalculateTotalMargin(IEnumerable<string> input)
        {
            var race = RaceReader.GetCombinedRaces(input);
            if (race == null)
            {
                return 0;
            }
            
            var lowestWinningInput = FindWinningStart(0, race.Time, race);
            var highestWinningInput = race.Time - lowestWinningInput;
            return highestWinningInput - lowestWinningInput + 1;
        }
        
        private static long FindWinningStart(long lowerBound, long upperBound, Race race)
        {
            if (lowerBound == upperBound)
            {
                return lowerBound;
            }

            if (lowerBound == upperBound - 1)
            {
                return upperBound;
            }
            
            var middle = (lowerBound + upperBound) / 2;

            return IsWin(middle, race) ? FindWinningStart(lowerBound, middle, race) : FindWinningStart(middle, upperBound, race);
        }

        private static IEnumerable<RaceOption> GetWinningRaceOptions(Race race)
        {
            for (long timePressed = 0; timePressed <= race.Time; timePressed++)
            {
                if (IsWin(timePressed, race))
                {
                    yield return new RaceOption(timePressed);
                }
            }
        }

        private static bool IsWin(long timePressed, Race race)
        {
            var speed = timePressed;
            var timeRemaining = race.Time - timePressed;
            var distanceTravelled = speed * timeRemaining;
            
            return distanceTravelled > race.Distance;
        }
    }
}
