using System;
using FluentAssertions;
using Nasa.MarsMission.Rovers.Basic;
using Nasa.MarsMission.Rovers.Core.Agent;
using Xunit;

namespace Nasa.MarsMission.Rovers.Test
{
    public class BasicRoverTest
    {
        [Theory]
        [InlineData(0, new[] {0, 0}, 1, new[] {1, 0})]
        [InlineData(0, new[] {0, 0}, 3, new[] {3, 0})]
        [InlineData(90, new[] {3, 4}, 3, new[] {3, 7})]
        [InlineData(180, new[] {10, 4}, 5, new[] {5, 4})]
        [InlineData(270, new[] {10, 4}, 3, new[] {10, 1})]
        public void Move_should_update_to_the_correct_position_given_initial_state(
            int initialBearing,
            int[] initialPosition,
            int magnitude,
            int[] expectedFinalPosition
            )
        {
            // arrange
            var rover = new BasicRover
            {
                Bearing = initialBearing,
                Position = initialPosition
            };

            // act
            var updatedPosition = rover.Move(magnitude);

            // assert
            updatedPosition.Should().Equal(expectedFinalPosition);
            updatedPosition.Should().Equal(rover.Position);

            rover.Bearing.Should().Be(initialBearing); // the bearing should not change
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void Move_should_throw_for_nonpositive_magnitude(int magnitude)
        {
            // arrange
            var rover = new BasicRover();
            
            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => rover.Move(magnitude));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(361)]
        [InlineData(-95)]
        [InlineData(-1000)]
        public void Move_should_throw_for_invalid_current_bearing(int initialBearing)
        {
            // arrange
            var rover = new BasicRover
            {
                Bearing = initialBearing
            };
            
            // act/assert
            Assert.Throws<InvalidOperationException>(() => rover.Move(1));
        }
        
        [Theory]
        [InlineData(0, 90, 90)]
        [InlineData(0, -90, 270)]
        [InlineData(270, 90, 0)]
        [InlineData(180, -90, 90)]
        [InlineData(180, 270, 90)]
        [InlineData(270, 270, 180)]
        [InlineData(270, 360, 270)]
        public void Rotate_should_update_to_the_correct_bearing_given_initial_state(
            int initialBearing,
            int angleOfRotation,
            int expectedFinalBearing
        )
        {
            // arrange
            var initialPosition = new[] {4, 14};
            var rover = new BasicRover
            {
                Bearing = initialBearing,
                Position = initialPosition
            };

            // act
            var updatedBearing = rover.Rotate(angleOfRotation);

            // assert
            updatedBearing.Should().Be(expectedFinalBearing);
            updatedBearing.Should().Be(rover.Bearing);

            rover.Position.Should().Equal(initialPosition); // position should not change
        }

        [Theory]
        [InlineData(20)]
        [InlineData(40)]
        [InlineData(1000)]
        [InlineData(-3)]
        public void Rotate_should_throw_for_non_90_degree_rotations(int angleOfRotation)
        {
            // arrange
            var rover = new BasicRover();
            
            // act/assert
            Assert.Throws<ArgumentOutOfRangeException>(() => rover.Rotate(angleOfRotation));
        }
        
        [Theory]
        [InlineData(0, new[] {0, 0}, ActionType.Move, 1, 0, new[] {1, 0})]
        [InlineData(90, new[] {6, 23}, ActionType.Move, 5, 90, new[] {6, 28})]
        [InlineData(180, new[] {6, 23}, ActionType.Rotate, -90, 90, new[] {6, 23})]
        [InlineData(270, new[] {6, 23}, ActionType.Rotate, 270, 180, new[] {6, 23})]
        public void Receive_should_correctly_process_action_given_initial_state(
            int initialBearing,
            int[] initialPosition,
            ActionType actionType,
            int actionValue,
            int expectedFinalBearing,
            int[] expectedFinalPosition
        )
        {
            // arrange
            var rover = new BasicRover
            {
                Bearing = initialBearing,
                Position = initialPosition
            };
            var roverAction = new RoverAction {Type = actionType, Value = actionValue};

            // act
            rover.Receive(roverAction);

            // assert
            rover.Position.Should().Equal(expectedFinalPosition);
            rover.Bearing.Should().Be(expectedFinalBearing);
        }
    }
}