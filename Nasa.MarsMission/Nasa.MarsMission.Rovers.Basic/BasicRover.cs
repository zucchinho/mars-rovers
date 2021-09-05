using System;
using Nasa.MarsMission.Rovers.Basic.Helpers;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicRover : SurfaceRoverBase
    {
        protected override int[] Move(int magnitude)
        {
            // we could process negatives, but given the basic implementation, we'll simply throw
            if (magnitude < 1)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(magnitude),
                    $"Magnitude should be greater than 0. Magnitude received: {magnitude}");
            }

            var vector = Status.Bearing switch
            {
                0 =>
                    // east
                    new[] {magnitude, 0},
                90 =>
                    // north
                    new[] {0, magnitude},
                180 =>
                    // west
                    new[] {-magnitude, 0},
                270 =>
                    // south
                    new[] {0, -magnitude},
                _ => throw new InvalidOperationException(
                    $"Current bearing does not correspond to a compass direction. Current bearing: {Bearing}")
            };

            Position[0] += vector[0];
            Position[1] += vector[1];

            return Position;
        }

        protected override int Rotate(int angleOfRotation)
        {
            if (angleOfRotation % 90 != 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(angleOfRotation),
                    $"Angle of rotation must be multiple of 90. Angle of rotation: {angleOfRotation}");
            }

            return Bearing = OrientationHelpers.NormalizeAngle(Bearing + angleOfRotation);
        }
    }
}