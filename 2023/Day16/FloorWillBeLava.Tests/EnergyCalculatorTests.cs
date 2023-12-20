namespace FloorWillBeLava.Tests;

public class EnergyCalculatorTests
{
    private const string Input = """
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
    
    [Fact]
    public void EnergizedTiles_Example()
    {
        var tiles = EnergyCalculator.EnergizedTiles(Input.Split(Environment.NewLine));
        
        Assert.Equal(46, tiles);
    }

    [Fact]
    public void MaxEnergizedTiles_Example()
    {
        var tiles = EnergyCalculator.MaxEnergizedTiles(Input.Split(Environment.NewLine));
        
        Assert.Equal(51, tiles);
    }
}