using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Day2_Dive.UnitTests
{
    public class PositionTrackerPart2Tests
    {
        private IFixture fixture = new Fixture();

        [Fact]
        public void Forward_moves_HorizontalPosition()
        {
            var sut = new PositionTrackerPart2();
            int steps = fixture.Create<int>();
            
            sut.Forward(steps);

            sut.HorizontalPostion.Should().Be(steps);
            sut.Depth.Should().Be(0);
            sut.Aim.Should().Be(0);
        }

        [Fact]
        public void Forward_moves_Aim()
        {
            var sut = new PositionTrackerPart2();
            int stepsDown = fixture.Create<int>();
            int stepsForward = fixture.Create<int>();

            sut.Down(stepsDown);
            sut.Forward(stepsForward);

            sut.HorizontalPostion.Should().Be(stepsForward);
            sut.Depth.Should().Be(stepsDown * stepsForward);
            sut.Aim.Should().Be(stepsDown);
        }

        [Fact]
        public void Up_changes_Depth()
        {
            var sut = new PositionTrackerPart2();
            int steps = fixture.Create<int>();

            sut.Up(steps);

            sut.HorizontalPostion.Should().Be(0);
            sut.Depth.Should().Be(0);
            sut.Aim.Should().Be(-steps);
        }

        [Fact]
        public void Down_changes_Depth()
        {
            var sut = new PositionTrackerPart2();
            int steps = fixture.Create<int>();

            sut.Down(steps);

            sut.HorizontalPostion.Should().Be(0);
            sut.Depth.Should().Be(0);
            sut.Aim.Should().Be(steps);
        }
    }
}