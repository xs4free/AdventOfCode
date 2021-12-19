namespace Day2_Dive
{
    public interface IPositionTracker
    {
        int Depth { get; }
        int HorizontalPostion { get; }

        void Down(int steps);
        void Forward(int steps);
        void Up(int steps);
    }
}