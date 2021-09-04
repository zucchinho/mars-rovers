using System;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicRover : CartesianFlatRover, IDeployedRover
    {
        public string Designation { get; set; }
        public bool Ready { get; set; }
        public int CommandsProcessed { get; set; }

        protected override int[] GetTranslation(int magnitude)
        {
            // we could process negatives, but given the basic implementation, we'll simply throw
            if (magnitude < 1)
            {
                throw new ArgumentOutOfRangeException(
                    $"Magnitude should be greater than 0. Magnitude received: {magnitude}",
                    nameof(magnitude));
            }

            return Bearing switch
            {
                0 =>
                    // east
                    new[] {1, 0},
                90 =>
                    // north
                    new[] {0, 1},
                180 =>
                    // west
                    new[] {-1, 0},
                270 =>
                    // south
                    new[] {0, -1},
                _ => throw new InvalidOperationException(
                    $"Current bearing does not correspond to a compass direction. Current bearing: {Bearing}")
            };
        }

        protected override int CalculateBearing(int angleOfRotation)
        {
            // while we could process values outside this range, they are probably given in error,
            // therefore it's safer to throw. Turning -270 degrees to turn left is a waste of solar!
            if (angleOfRotation != 90 && angleOfRotation != -90)
            {
                throw new ArgumentException(
                    $"Angle of rotation must be -90 or 90 degrees. Angle of rotation: {angleOfRotation}",
                    nameof(angleOfRotation));
            }

            // calculate the equivalent anticlockwise rotation angle
            var acRotation = angleOfRotation < 0 ? 360 - angleOfRotation : angleOfRotation;

            // add it to the current bearing
            Bearing += acRotation;
            
            // get the remainder from 360 to get the bearing
            Bearing %= 360;

            return Bearing;
        }
    }
}