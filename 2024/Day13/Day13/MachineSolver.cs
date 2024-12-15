namespace Day13;

public static class MachineSolver
{
    public static int? CostOfCheapestSolution(MachineBehaviour machineBehaviour)
    {
        var validButtonCombinations = GenerateValidCombinations(machineBehaviour).ToList();
        if (validButtonCombinations.Count == 0)
        {
            return null;
        }
        
        var cheapestCost = validButtonCombinations
            .Min(combination => combination.button1 * machineBehaviour.Buttons[0].TokenCost + combination.button2 * machineBehaviour.Buttons[1].TokenCost);
        
        return cheapestCost;
    }

    private static IEnumerable<(int button1, int button2)> GenerateValidCombinations(MachineBehaviour machineBehaviour)
    {
        var button1 = machineBehaviour.Buttons[0];
        var button2 = machineBehaviour.Buttons[1];
        
        for (var click1 = 0; click1 <= 100; click1++)
        {
            for (var click2 = 0; click2 <= 100; click2++)
            {
                var x = (button1.Offset.Dx * click1) + (button2.Offset.Dx * click2);
                var y = (button1.Offset.Dy * click1) + (button2.Offset.Dy * click2);

                if (machineBehaviour.PrizeLocation.X == x && machineBehaviour.PrizeLocation.Y == y)
                {
                    yield return (click1, click2);
                }
            }
        }
    }
}
