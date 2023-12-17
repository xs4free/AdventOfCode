namespace LensLibrary.Tests;

public class HashTests
{
    [Theory]
    [InlineData("rn=1", 30)]
    [InlineData("cm-", 253)]
    [InlineData("qp=3", 97)]
    [InlineData("cm=2", 47)]
    [InlineData("qp-", 14)]
    [InlineData("pc=4", 180)]
    [InlineData("ot=9", 9)]
    [InlineData("ab=5", 197)]
    [InlineData("pc-", 48)]
    [InlineData("pc=6", 214)]
    [InlineData("ot=7", 231)]
    [InlineData("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7", 1320)]
    public void Compute(string input, long expectedResult)
    {
        var result = Hash.Compute(input);
        
        Assert.Equal(expectedResult, result);
    }
}