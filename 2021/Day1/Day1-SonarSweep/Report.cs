namespace Day1_SonarSweep
{
    public class Report
    {
        public int Lines { get; set; }    
        public int Increases { get; set; }
        public int Decreases { get; set; }

        public IList<string> Output { get; set; } = new List<string>();
    }
}
