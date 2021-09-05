using System;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicRover : BaseDeployedRover
    {
        private int _bearing;
        
        public override int[] Move(int magnitude)
        {
            // we could process negatives, but given the basic implementation, we'll simply throw
            if (magnitude < 1)
            {
                throw new ArgumentOutOfRangeException(
                    $"Magnitude should be greater than 0. Magnitude received: {magnitude}",
                    nameof(magnitude));
            }

            var vector = Bearing switch
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

        public override int Rotate(int angleOfRotation)
        {
            if (angleOfRotation % 90 != 0)
            {
                throw new ArgumentOutOfRangeException(
                    $"Angle of rotation must be multiple of 90. Angle of rotation: {angleOfRotation}",
                    nameof(angleOfRotation));
            }

            return Bearing = NormalizeAngle(Bearing + angleOfRotation);
        }

        public override int Bearing
        {
            get => _bearing;
            // ensure bearing is 0 - 360
            set => _bearing = NormalizeAngle(value);
        }

        public override int[] Position { get; set; } = {0, 0};

        private static int NormalizeAngle(int angle)
        {
            // normalize to -359 to 359
            angle %= 360;
            
            // if its negative, add 360 to give the coterminal angle (equiv. between 0 and 359)
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }
    }
}