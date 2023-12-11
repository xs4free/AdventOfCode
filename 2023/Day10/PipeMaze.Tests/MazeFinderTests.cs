namespace PipeMaze.Tests;

public class MazeFinderTests
{
    [Fact]
    public void StepsToFarthestPoint_Example1_Simple()
    {
        const string input = """
                             .....
                             .S-7.
                             .|.|.
                             .L-J.
                             .....
                             """;
        var steps = MazeFinder.StepsToFarthestPoint(input.Split(Environment.NewLine));
        Assert.Equal(4, steps);
    }

    [Fact]
    public void StepsToFarthestPoint_Example1_Complex()
    {
        const string input = """
                             -L|F7
                             7S-7|
                             L|7||
                             -L-J|
                             L|-JF    
                             """;
        var steps = MazeFinder.StepsToFarthestPoint(input.Split(Environment.NewLine));
        Assert.Equal(4, steps);
    }

    [Fact]
    public void StepsToFarthestPoint_Example2_Simple()
    {
        const string input = """
                             ..F7.
                             .FJ|.
                             SJ.L7
                             |F--J
                             LJ...
                             """;
        var steps = MazeFinder.StepsToFarthestPoint(input.Split(Environment.NewLine));
        Assert.Equal(8, steps);
    }
    
    [Fact]
    public void StepsToFarthestPoint_Example2_Complex()
    {
        const string input = """
                             7-F7-
                             .FJ|7
                             SJLL7
                             |F--J
                             LJ.LJ
                             """;
        var steps = MazeFinder.StepsToFarthestPoint(input.Split(Environment.NewLine));
        Assert.Equal(8, steps);
    }
}