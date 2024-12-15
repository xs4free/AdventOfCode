namespace Day13.Tests;

public class MachineSolverTests
{
    [Fact]
    public void CostOfCheapestSolution_Part1_Example0_1()
    {
        string[] input = 
        [
            "Button A: X+94, Y+34",
            "Button B: X+22, Y+67",
            "Prize: X=8400, Y=5400",
        ];
        
        var behaviours = InputParser.Parse(input).ToList();
        var result = MachineSolver.CostOfCheapestSolution(behaviours[0]);
        
        Assert.Equal(280, result);
    }
    
    [Fact]
    public void CostOfCheapestSolution_Part1_Example0_2()
    {
        string[] input = 
        [
            "Button A: X+26, Y+66",
            "Button B: X+67, Y+21",
            "Prize: X=12748, Y=12176"
        ];
        
        var behaviours = InputParser.Parse(input).ToList();
        var result = MachineSolver.CostOfCheapestSolution(behaviours[0]);
        
        Assert.Null(result);
    }
    
    [Fact]
    public void CostOfCheapestSolution_Part1_Example1()
    {
        string[] input = 
        [
            "Button A: X+94, Y+34",
            "Button B: X+22, Y+67",
            "Prize: X=8400, Y=5400",
            "",
            "Button A: X+26, Y+66",
            "Button B: X+67, Y+21",
            "Prize: X=12748, Y=12176",
            "",
            "Button A: X+17, Y+86",
            "Button B: X+84, Y+37",
            "Prize: X=7870, Y=6450",
            "",
            "Button A: X+69, Y+23",
            "Button B: X+27, Y+71",
            "Prize: X=18641, Y=10279"
        ];
        
        var behaviours = InputParser.Parse(input).ToList();
        
        var result = behaviours.Sum(MachineSolver.CostOfCheapestSolution);
        
        Assert.Equal(480, result);
    }    
}