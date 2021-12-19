using AutoFixture;
using FluentAssertions;
using Xunit;

namespace Day2_Dive.UnitTests
{
    public class PositionTrackerPart1Tests
    {
        private IFixture fixture = new Fixture();

        [Fact]
        public void Forward_moves_HorizontalPosition()
        {
            var sut = new PositionTrackerPart1();
            int steps = fixture.Create<int>();
            
            sut.Forward(steps);

            sut.HorizontalPostion.Should().Be(steps);
            sut.Depth.Should().Be(0);
        }

        [Fact]
        public void Up_changes_Depth()
        {
            var sut = new PositionTrackerPart1();
            int steps = fixture.Create<int>();

            sut.Up(steps);

            sut.Depth.Should().Be(-steps);
            sut.HorizontalPostion.Should().Be(0);
        }

        [Fact]
        public void Down_changes_Depth()
        {
            var sut = new PositionTrackerPart1();
            int steps = fixture.Create<int>();

            sut.Down(steps);

            sut.Depth.Should().Be(steps);
            sut.HorizontalPostion.Should().Be(0);
        }
    }
}