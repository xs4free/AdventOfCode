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
        var sum = MirrorFinder.SummarizeAllNotes(Input1.Split(Environment.NewLine), repairSmudge: false);
        
        Assert.Equal(5, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example2()
    {
        var sum = MirrorFinder.SummarizeAllNotes(Input2.Split(Environment.NewLine), repairSmudge: false);
        
        Assert.Equal(400, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example3()
    {
        var sum = MirrorFinder.SummarizeAllNotes(_input3.Split(Environment.NewLine), repairSmudge: false);
        
        Assert.Equal(405, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example1_Repair()
    {
        var sum = MirrorFinder.SummarizeAllNotes(Input1.Split(Environment.NewLine), repairSmudge: true);
        
        Assert.Equal(300, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example2_Repair()
    {
        var sum = MirrorFinder.SummarizeAllNotes(Input2.Split(Environment.NewLine), repairSmudge: true);
        
        Assert.Equal(100, sum);
    }
    
    [Fact]
    public void SummarizeAllNotes_Example3_Repair()
    {
        var sum = MirrorFinder.SummarizeAllNotes(_input3.Split(Environment.NewLine), repairSmudge: true);
        
        Assert.Equal(400, sum);
    }

    [Fact]
    public async Task SummarizeAllNotes_FullInput_Repair()
    {
        const string inputFile = @"../../../../Input-Day13.txt";
        var lines = await File.ReadAllLinesAsync(inputFile);
        var sum = MirrorFinder.SummarizeAllNotes(lines, repairSmudge: true);

        Assert.NotEqual(38325, sum);
    }
}