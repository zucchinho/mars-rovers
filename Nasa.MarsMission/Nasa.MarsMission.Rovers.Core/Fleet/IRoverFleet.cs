using System.Collections.Generic;
using Nasa.MarsMission.Rovers.Core.Agent;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public interface IRoverFleet<TRover> : ICollection<TRover>
        where TRover : IRover
    {
        TRover ActiveRover { get; }
    }
}