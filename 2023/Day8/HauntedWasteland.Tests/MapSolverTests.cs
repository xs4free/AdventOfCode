namespace HauntedWasteland.Tests;

public class MapSolverTests
{
    [Fact]
    public void StepsTo_Example1()
    {
        const string input = """
                             RL

                             AAA = (BBB, CCC)
                             BBB = (DDD, EEE)
                             CCC = (ZZZ, GGG)
                             DDD = (DDD, DDD)
                             EEE = (EEE, EEE)
                             GGG = (GGG, GGG)
                             ZZZ = (ZZZ, ZZZ)
                             """;

        var stepsTo = MapSolver.StepsTo(input.Split(Environment.NewLine));
        
        Assert.Equal(2, stepsTo);
    }
    
    [Fact]
    public void StepsTo_Example2()
    {
        const string input = """
                             LLR
                             
                             AAA = (BBB, BBB)
                             BBB = (AAA, ZZZ)
                             ZZZ = (ZZZ, ZZZ)
                             """;

        var stepsTo = MapSolver.StepsTo(input.Split(Environment.NewLine));
        
        Assert.Equal(6, stepsTo);
    }
    
}