namespace Nasa.MarsMission.Rovers.Basic
{
    /// <summary>
    /// Possible types of action for a rover
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Move some specified magnitude on current bearing
        /// </summary>
        Move,
        
        /// <summary>
        /// Rotate by a specified angle of rotation
        /// </summary>
        Rotate,
        
        /// <summary>
        /// Travel vertically
        /// </summary>
        Vertical
    }
}