namespace Nasa.MarsMission.Rovers.Airborne
{
    /// <summary>
    /// Possible types of action for a rover
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Move some specified magnitude on current bearing
        /// </summary>
        Horizontal,
        
        /// <summary>
        /// Travel vertically
        /// </summary>
        Vertical,
        
        /// <summary>
        /// Rotate by a specified angle of rotation
        /// </summary>
        Rotate
    }
}