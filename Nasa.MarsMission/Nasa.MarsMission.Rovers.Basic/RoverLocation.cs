using Nasa.MarsMission.Rovers.Basic.Helpers;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class RoverLocation
    {
        /// <summary>
        /// Coordinates [x,y] representing the rover's current position
        /// </summary>
        public int[] Position { get; set; } = {0, 0};
        
        /// <summary>
        /// Degree value representing rover's current bearing
        /// </summary>
        public int Bearing { get; set; }

        public override string ToString()
        {
            return $"{string.Join(' ', Position)} {OrientationHelpers.ConvertToCompassDirection(Bearing)}";
        }
    }
}