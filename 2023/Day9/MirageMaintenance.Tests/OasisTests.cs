namespace MirageMaintenance.Tests;

public class OasisTests
{
    private const string Input = """
                         0 3 6 9 12 15
                         1 3 6 10 15 21
                         10 13 16 21 30 45
                         """;
    
    [Fact]
    public void PredictAllNextValues_Example1()
    {
        var sum = Oasis.PredictAllValues(Input.Split(Environment.NewLine), PredictDirection.Next);
        
        Assert.Equal(114, sum);
    }
    
    [Fact]
    public void PredictAllPreviousValues_Example1()
    {
        var sum = Oasis.PredictAllValues(Input.Split(Environment.NewLine), PredictDirection.Previous);
        
        Assert.Equal(2, sum);
    }
    
}