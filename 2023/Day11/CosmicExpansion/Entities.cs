namespace CosmicExpansion;

internal record Galaxy(int Number, int X, int Y);

internal class GalaxyPair(Galaxy galaxy1, Galaxy galaxy2, int shortestPath)
{
    public Galaxy Galaxy1 { get; init; } = galaxy1;
    public Galaxy Galaxy2 { get; init; } = galaxy2;
    public int ShortestPath { get; set; } = shortestPath;
}