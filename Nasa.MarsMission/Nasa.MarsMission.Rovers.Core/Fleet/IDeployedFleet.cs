using System.Collections.Generic;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    /// <summary>
    /// Represents a fleet of deployed rovers
    /// </summary>
    /// <typeparam name="TRover">The type of deployed rover.</typeparam>
    public interface IDeployedFleet<out TRover> : IInputReceiver<IReadOnlyList<string>>
        where TRover : IInputReceiver<string>
    {
        /// <summary>
        /// The list of currently deployed rovers
        /// </summary>
        IReadOnlyCollection<TRover> Rovers { get; }
    }
}