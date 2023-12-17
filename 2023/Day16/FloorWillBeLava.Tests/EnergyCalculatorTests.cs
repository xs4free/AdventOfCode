namespace FloorWillBeLava.Tests;

public class EnergyCalculatorTests
{
    [Fact]
    public void EnergizedTiles_Example()
    {
        const string input = """
                             .|...\....
                             |.-.\.....
                             .....|-...
                             ........|.
                             ..........
                             .........\
                             ..../.\\..
                             .-.-/..|..
                             .|....-|.\
                             ..//.|....
                             """;

        var tiles = EnergyCalculator.EnergizedTiles(input.Split(Environment.NewLine));
        
        Assert.Equal(46, tiles);
    }
}