namespace Nasa.MarsMission.Rovers.Core.Description
{
    public interface IRoverLocation
    {
        /// <summary>
        /// Coordinates [x,y] representing the rover's current position
        /// </summary>
        int[] Position { get; set; }
        
        /// <summary>
        /// Degree value representing rover's current bearing
        /// </summary>
        int Bearing { get; set; }
    }
}