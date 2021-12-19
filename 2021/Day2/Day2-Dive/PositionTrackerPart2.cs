namespace Day2_Dive
{
    public class PositionTrackerPart2 : IPositionTracker
    {
        public int HorizontalPostion { get; private set; }
        public int Depth { get; private set; }
        public int Aim { get; private set; }

        public void Forward(int steps)
        {
            HorizontalPostion += steps;
            Depth += Aim * steps;
        }

        public void Down(int steps)
        {
            Aim += steps;
        }

        public void Up(int steps)
        {
            Aim -= steps;
        }
    }
}
