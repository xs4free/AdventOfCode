namespace LensLibrary.Tests;

public class HashmapTests
{
    [Fact]
    public void FocussingPower_Example()
    {
        const string input = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";

        var focussingPower = Hashmap.FocussingPower(input);
        
        Assert.Equal(145, focussingPower);
    }
}