namespace Day09.Tests;

internal static class SectorAssert
{
    internal static void AssertSectors(List<Sector> sectors, string expectedSectorsAsString)
    {
        Assert.Equal(expectedSectorsAsString.Length, sectors.Count);
        
        var expectedSectors = SectorFactory.CreateSectorsFromString(expectedSectorsAsString).ToList();

        for (var i = 0; i < expectedSectors.Count; i++)
        {
            Assert.Equal(expectedSectors[i], sectors[i]);
        }
    }
}