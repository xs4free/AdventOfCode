namespace Day2_Dive
{
    public class InputProcessor
    {
        private readonly IPositionTracker tracker;

        public InputProcessor(IPositionTracker tracker)
        {
            this.tracker = tracker;
        }

        public void ProcessLines(IEnumerable<string> lines)
        {
            var splitLines = lines.Select(line => line.Split(new[] { ' ' }));
            var commands = splitLines.Select(line => new { Command = Enum.Parse<Commands>(line[0]), Steps = Convert.ToInt32(line[1]) });

            foreach (var command in commands)
            {
                switch (command.Command)
                {
                    case Commands.forward:
                        tracker.Forward(command.Steps);
                        break;
                    case Commands.down:
                        tracker.Down(command.Steps);
                        break;
                    case Commands.up:
                        tracker.Up(command.Steps);
                        break;
                    default:
                        throw new Exception($"Unknown command found: {command.Command}");
                }
            }
        }
    }
}
