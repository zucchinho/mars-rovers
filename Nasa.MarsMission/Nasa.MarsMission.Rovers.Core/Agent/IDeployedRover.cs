using Nasa.MarsMission.Rovers.Core.Description;

namespace Nasa.MarsMission.Rovers.Core.Agent
{
    /// <summary>
    /// Represents a rover deployed to an environment
    /// </summary>
    /// <typeparam name="TStatus">The rover status.</typeparam>
    public interface IDeployedRover<TStatus> : IInputReceiver<string>, IRoverDetails
    {
        /// <summary>
        /// The current status of the rover e.g. containing positional information
        /// </summary>
        TStatus Status { get; set; }
    }
}