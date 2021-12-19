namespace Day2_Dive
{
    public class PositionTracker
    {
        public int HorizontalPostion { get; private set; }
        public int Depth { get; private set; }

        public void Forward(int steps)
        {
            HorizontalPostion += steps;
        }

        public void Down(int steps)
        {
            Depth += steps;
        }

        public void Up(int steps)
        {
            Depth -= steps;
        }
    }
}
