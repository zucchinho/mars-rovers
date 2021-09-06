namespace Nasa.MarsMission.Rovers.Core.Description
{
    /// <summary>
    /// Represents the inherent details of a rover
    /// </summary>
    public interface IRoverDetails
    {
        /// <summary>
        /// The unique name of the rover
        /// </summary>
        string Designation { get; set; }

        /// <summary>
        /// Whether rover is ready to receive commands
        /// </summary>
        bool Ready { get; set; }

        /// <summary>
        /// The number of commands processed by this rover
        /// </summary>
        int CommandsProcessed { get; set; }
    }
}