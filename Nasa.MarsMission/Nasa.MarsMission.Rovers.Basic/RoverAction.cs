namespace Nasa.MarsMission.Rovers.Basic
{
    /// <summary>
    /// Represents a discrete action for a rover to perform
    /// </summary>
    public class RoverAction
    {
        /// <summary>
        /// The relevant value e.g. a magnitude
        /// </summary>
        public int Value { get; set; }
        
        /// <summary>
        /// The type of action to perform e.g. Move
        /// </summary>
        public ActionType Type { get; set; }
    }
}