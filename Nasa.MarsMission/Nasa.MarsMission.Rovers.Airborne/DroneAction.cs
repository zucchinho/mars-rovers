namespace Nasa.MarsMission.Rovers.Airborne
{
    /// <summary>
    /// Represents a discrete action for a drone to perform
    /// </summary>
    public class DroneAction
    {
        /// <summary>
        /// The relevant value e.g. a magnitude
        /// </summary>
        public double Value { get; set; }
        
        /// <summary>
        /// The type of action to perform e.g. Move
        /// </summary>
        public ActionType Type { get; set; }
    }
}