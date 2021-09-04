namespace Nasa.MarsMission.Rovers.Core
{
    public interface IRoverLocation
    {
        /// <summary>
        /// Coordinates [x,y] representing the rover's current position
        /// </summary>
        int[] Position { get; }
        
        /// <summary>
        /// Degree value representing rover's current bearing
        /// </summary>
        int Bearing { get; }
    }
}