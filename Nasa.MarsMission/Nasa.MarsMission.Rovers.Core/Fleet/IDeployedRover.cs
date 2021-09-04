using Nasa.MarsMission.Rovers.Core.Agent;
using Nasa.MarsMission.Rovers.Core.Description;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public interface IDeployedRover : IRover, IRoverDetails, IRoverLocation
    {
        IDeployedRover Receive(RoverAction roverAction);
    }
}