using System.Collections.Generic;

namespace Nasa.MarsMission.Rovers.Core
{
    public interface IRoverFleet<TRover> : ICollection<TRover>
        where TRover : IRover
    {
        TRover ActiveRover { get; }
    }
}