using System.Collections.Generic;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public interface IDeployedFleet<out TRover> : IInputReceiver<IReadOnlyList<string>>
        where TRover : IInputReceiver<string>
    {
        IReadOnlyCollection<TRover> Rovers { get; }
    }
}