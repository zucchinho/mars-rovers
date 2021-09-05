namespace Nasa.MarsMission.Rovers.Core.Description.Terrain
{
    public interface ITerrain<in TRoverStatus>
    {
        /// <summary>
        /// The dimensions of the boundary
        /// </summary>
        int[] Dimensions { get; set; }
        
        /// <summary>
        /// Determines if provided rover status is out of bounds
        /// </summary>
        /// <param name="position">The position to check.</param>
        /// <returns><c>true</c> if out of bounds, else <c>false</c></returns>
        bool IsOutOfBounds(TRoverStatus position);
    }
}