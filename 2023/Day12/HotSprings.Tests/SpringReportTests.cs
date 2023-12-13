using FluentAssertions;
namespace HotSprings.Tests;

public class SpringReportTests
{
    [Fact]
    public void SumOfArrangements_Example()
    {
        const string input = """
                             ???.### 1,1,3
                             .??..??...?##. 1,1,3
                             ?#?#?#?#?#?#?#? 1,3,1,6
                             ????.#...#... 4,1,1
                             ????.######..#####. 1,6,5
                             ?###???????? 3,2,1
                             """;
        
        var result = SpringReport.SumOfArrangements(input.Split(Environment.NewLine));
        
        Assert.Equal(21, result);
    }

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    [InlineData("#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.#...#... 4,1,1", 1)]
    [InlineData("????.######..#####. 1,6,5", 4)]
    [InlineData("?###???????? 3,2,1", 10)]
    public void SumOfArrangements_Example_PerLine(string input, int expectedResult)
    {
        var result = SpringReport.SumOfArrangements(new[] { input });
        
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