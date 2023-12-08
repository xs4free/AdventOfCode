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
            
            int power = winningRaceCombinations.First();
            foreach (var combination in winningRaceCombinations.Skip(1))
            {
                power *= combination;
            }
            
            return power;
        }

        private static IEnumerable<RaceOption> GetWinningRaceOptions(Race race)
        {
            for (int timePressed = 0; timePressed <= race.Time; timePressed++)
            {
                int speed = timePressed;
                int timeRemaining = race.Time - timePressed;
                int distanceTravelled = timeRemaining * speed;

                if (distanceTravelled > race.Distance)
                {
                    yield return new RaceOption(timePressed, distanceTravelled);
                }
            }
        }
    }
}
