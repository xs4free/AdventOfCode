using FluentAssertions;
namespace HotSprings.Tests;

public class SpringReportTests
{
    private const string Input = """
                         ???.### 1,1,3
                         .??..??...?##. 1,1,3
                         ?#?#?#?#?#?#?#? 1,3,1,6
                         ????.#...#... 4,1,1
                         ????.######..#####. 1,6,5
                         ?###???????? 3,2,1
                         """;
    
    [Fact]
    public void SumOfArrangements_Example_Folded()
    {
        var result = SpringReport.SumOfArrangements(Input.Split(Environment.NewLine), 1);
        
        Assert.Equal(21, result);
    }
    
    [Fact]
    public void SumOfArrangements_Example_Unfolded()
    {
        var result = SpringReport.SumOfArrangements(Input.Split(Environment.NewLine), 5);
        
        Assert.Equal(525152, result);
    }
    

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    [InlineData("#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 1)]
    [InlineData("????.######..#####. 1,6,5", 4)]
    [InlineData("?###???????? 3,2,1", 10)]
    public void SumOfArrangements_Example_PerLine_Folded(string input, int expectedResult)
    {
        var result = SpringReport.SumOfArrangements(new[] { input }, 1);
        
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 16384)]
    [InlineData("#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 16)]
    [InlineData("????.######..#####. 1,6,5", 2500)]
    [InlineData("?###???????? 3,2,1", 506250)]
    public void SumOfArrangements_Example_PerLine_Unfolded(string input, int expectedResult)
    {
        var result = SpringReport.SumOfArrangements(new[] { input }, 5);
        
        Assert.Equal(expectedResult, result);
    }
    
    public static IEnumerable<object[]> GetBrokenPipeGroupsData =>
        new List<object[]>
        {
            new object[] { "#.#.###", new List<int> { 1,1,3 }},
            new object[] { ".#...#....###.", new List<int> {1,1,3 }},
            new object[] { ".#.###.#.######", new List<int> {1,3,1,6 }},
            new object[] { "####.#...#...", new List<int> {4,1,1 }},
            new object[] { "#....######..#####.", new List<int> {1,6,5 }},
            new object[] { ".###.##....#", new List<int> { 3,2,1}}
        };

    [Theory, MemberData(nameof(GetBrokenPipeGroupsData))]
    public void GetBrokenPipeGroups_validate_count(string input, List<int> expectedResult)
    {
        var result = SpringReport.GetBrokenPipeGroups(input.ToCharArray());
        result.Should().Equal(expectedResult);
    }
}