using System;
using System.Collections.Generic;
using System.Linq;

namespace Nasa.MarsMission.Rovers.Basic.Helpers
{
    public static class OrientationHelpers
    {
        private static readonly Dictionary<string, int> CompassDirectionDictionary = new Dictionary<string, int>
        {
            {"E", 0},
            {"N", 90},
            {"W", 180},
            {"S", 270}
        };

        public static int ConvertFromCompassDirection(string direction)
        {
            if (!CompassDirectionDictionary.TryGetValue(direction, out var bearing))
            {
                throw new ArgumentOutOfRangeException(nameof(direction));
            }

            return bearing;
        }

        public static string ConvertToCompassDirection(int bearing)
        {
            var direction = CompassDirectionDictionary
                .FirstOrDefault(e => e.Value == bearing)
                .Key;
            if (direction == null)
            {
                throw new ArgumentOutOfRangeException(nameof(bearing));
            }

            return direction;
        }

        public static int NormalizeAngle(int angle)
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