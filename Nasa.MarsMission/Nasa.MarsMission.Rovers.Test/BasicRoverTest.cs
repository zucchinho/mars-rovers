using System;
using FluentAssertions;
using Nasa.MarsMission.Rovers.Basic;
using Nasa.MarsMission.Rovers.Core.Agent;
using Nasa.MarsMission.Rovers.Core.Description;
using Xunit;

namespace Nasa.MarsMission.Rovers.Test
{
    public class BasicRoverTest
    {
        /// <summary>
        /// Test sending a load of instructions to a rover instance
        /// </summary>
        /// <param name="initialBearing"></param>
        /// <param name="initialPosition"></param>
        /// <param name="input"></param>
        /// <param name="expectedFinalBearing"></param>
        /// <param name="expectedFinalPosition"></param>
        [Theory]
        // move
        [InlineData(0, new[] {0, 0}, "M", 0, new[] {1, 0})]
        [InlineData(0, new[] {0, 0}, "MMM", 0, new[] {3, 0})]
        [InlineData(90, new[] {3, 4}, "MMM", 90, new[] {3, 7})]
        [InlineData(180, new[] {10, 4}, "MMMMM", 180, new[] {5, 4})]
        [InlineData(270, new[] {10, 4}, "MMM", 270, new[] {10, 1})]
        // rotate
        [InlineData(0, new[] {5, 7}, "L", 90, new[] {5, 7})]
        [InlineData(0, new[] {5, 7}, "R", 270, new[] {5, 7})]
        [InlineData(270, new[] {5, 7}, "L", 0, new[] {5, 7})]
        [InlineData(180, new[] {5, 7}, "R", 90, new[] {5, 7})]
        [InlineData(180, new[] {5, 7}, "LLL", 90, new[] {5, 7})]
        [InlineData(270, new[] {5, 7}, "LLL", 180, new[] {5, 7})]
        [InlineData(270, new[] {5, 7}, "RRRR", 270, new[] {5, 7})]
        // combined
        [InlineData(0, new[] {0, 0}, "LMMRMM", 0, new[] {2, 2})]
        [InlineData(0, new[] {0, 0}, "MMMMMRMMRMM", 180, new[] {3, -2})]
        [InlineData(270, new[] {10, 5}, "MMLMMRMMMMRMM", 180, new[] {10, -1})]
        public void Receive_should_update_to_the_correct_state_given_initial_state(
            int initialBearing,
            int[] initialPosition,
            string input,
            int expectedFinalBearing,
            int[] expectedFinalPosition
        )
        {
            // arrange
            var status = new RoverLocation
            {
                Bearing = initialBearing,
                Position = initialPosition
            };
            var rover = new BasicRover
            {
                Status = status
            };

            // act
            rover.Receive(input);

            // assert
            rover.Status.Position.Should().Equal(expectedFinalPosition);
            rover.Status.Bearing.Should().Be(expectedFinalBearing);
        }
    }
}