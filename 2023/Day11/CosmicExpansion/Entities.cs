namespace CosmicExpansion;

internal record Galaxy(int Number, long X, long Y);

internal record GalaxyPair(Galaxy Galaxy1, Galaxy Galaxy2, long ShortestPath);

internal record Map(char[][] Position, List<long> RowExpansions, List<long> ColumnExpansions);