namespace MirageMaintenance.Tests;

public class OasisTests
{
    [Fact]
    public void PredictAll_Example1()
    {
        const string input = """
                             0 3 6 9 12 15
                             1 3 6 10 15 21
                             10 13 16 21 30 45
                             """;
        var sum = Oasis.PredictAll(input.Split(Environment.NewLine));
        
        Assert.Equal(114, sum);
    }
}