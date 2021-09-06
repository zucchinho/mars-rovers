using System;
using System.Text;
using FluentAssertions;
using Nasa.MarsMission.Rovers.Basic;
using Xunit;

namespace Nasa.MarsMission.Rovers.Test
{
    public class BasicFleetTest
    {
        /// <summary>
        /// Test the successfully issuing commands to the fleet
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="expectedOutputLines"></param>
        /// <param name="roverCount"></param>
        [Theory]
        [InlineData(new[] {"10 10"}, new[] {""}, 0)]
        [InlineData(new[] {"20 20", "10 10 N"}, new[] {"10 10 N"}, 1)]
        [InlineData(new[] {"20 20", "10 10 N", "RMMM"}, new[] {"13 10 E"}, 1)]
        // i/o specified in the exercise
        [InlineData(
            new[] {"5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"},  
            new[] {"1 3 N", "5 1 E"},
            2)]
        public void Receive_should_correctly_interpret_commands(
            string[] commands,
            string[] expectedOutputLines,
            int roverCount)
        {
            // arrange
            var fleet = new BasicFleet();
            var sb = new StringBuilder();

            foreach (var outputLine in expectedOutputLines)
            {
                sb.AppendLine(outputLine);
            }

            var expectedOutput = sb.ToString().Trim();

            // act
            fleet.Receive(commands);

            // assert
            fleet.Rovers.Count.Should().Be(roverCount);
            fleet.ToString().Should().Be(expectedOutput);
        }

        /// <summary>
        /// Test that the fleet correctly identifies out of bound states
        /// </summary>
        /// <param name="commands"></param>
        [Theory]
        [InlineData("10 10", "20 20")]
        [InlineData("20 20", "21 5")]
        [InlineData("20 20", "5 21")]
        [InlineData("20 20", "5 -5")]
        public void Deploy_should_throw_if_initial_position_out_of_bounds(
            params string[] commands)
        {
            // arrange
            var fleet = new BasicFleet();

            // act/assert
            Assert.Throws<ArgumentException>(()=> fleet.Receive(commands));
        }
    }
}