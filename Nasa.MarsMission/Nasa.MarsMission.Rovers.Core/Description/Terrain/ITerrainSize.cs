namespace Nasa.MarsMission.Rovers.Core.Description.Terrain
{
    public interface ITerrainSize
    {
        /// <summary>
        /// The dimensions of the boundary
        /// </summary>
        int[] Dimensions { get; }
        
        /// <summary>
        /// Determines if provided position is out of bounds
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns><c>true</c> if out of bounds, else <c>false</c></returns>
        bool IsOutOfBounds(int[] position);
    }
}