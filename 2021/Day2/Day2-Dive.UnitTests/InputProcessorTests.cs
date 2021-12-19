﻿using FluentAssertions;
using Xunit;

namespace Day2_Dive.UnitTests
{
    public class InputProcessorTests
    {
        [Fact]
        public void ProcessLines_example()
        {
            PositionTracker tracker = new();            
            var sut = new InputProcessor(tracker);
            string[] commandLines = new[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
            
            sut.ProcessLines(commandLines);

            tracker.HorizontalPostion.Should().Be(15);
            tracker.Depth.Should().Be(10);
        }
    }
}
