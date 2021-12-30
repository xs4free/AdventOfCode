namespace Day3_Binary_Diagnostic
{
    public record AnalyzerResults
    {
        public bool Valid { get; init; }
        public int GammaRate { get; init; }
        public int EpsilonRate { get; init; }
        public int PowerConsumption { get; init; }
        public int OxygenGeneratorRating { get; init; }
        public int CO2ScrubberRating { get; init; }
        public int LifeSupportRating { get; init; }
    }
}
