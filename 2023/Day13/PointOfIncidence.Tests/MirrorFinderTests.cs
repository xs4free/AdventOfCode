namespace PointOfIncidence.Tests;

public class MirrorFinderTests
{
    private const string Input1 = """
                                   #.##..##.
                                   ..#.##.#.
                                   ##......#
                                   ##......#
                                   ..#.##.#.
                                   ..##..##.
                                   #.#.##.#.
                                   """;

    private const string Input2 = """
                                   #...##..#
                                   #....#..#
                                   ..##..###
                                   #####.##.
                                   #####.##.
                                   ..##..###
                                   #....#..#
                                   """;

    private readonly string _input3 = Input1 + Environment.NewLine + Environment.NewLine + Input2;
    
    [Fact]
    public void SummarizeAllNotes_Example1()
    {
        var sum = MirrorFinder.SummarizeAllNotes(Input1.Split(Environment.NewLine));
        
        Assert.Equal(5, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example2()
    {
        var sum = MirrorFinder.SummarizeAllNotes(Input2.Split(Environment.NewLine));
        
        Assert.Equal(400, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example3()
    {
        var sum = MirrorFinder.SummarizeAllNotes(_input3.Split(Environment.NewLine));
        
        Assert.Equal(405, sum);
    }
}