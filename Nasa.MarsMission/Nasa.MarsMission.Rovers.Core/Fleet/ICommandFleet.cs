using Nasa.MarsMission.Rovers.Core.Agent;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public interface ICommandFleet<TRover> : IRoverFleet<TRover>
        where TRover : IRover
    {
        /// <summary>
        /// Deploy a new rover at the specified position and bearing
        /// </summary>
        /// <param name="position">The initial position for the deployed rover.</param>
        /// <param name="bearing">The initial bearing for the deployed rover</param>
        /// <returns>The deployed rover.</returns>
        TRover Deploy(int[] position, int bearing);
        
        /// <summary>
        /// Sends a command to the active rover
        /// </summary>
        /// <param name="command">The command string.</param>
        /// <returns>The active rover</returns>
        TRover Send(string command);
    }
}