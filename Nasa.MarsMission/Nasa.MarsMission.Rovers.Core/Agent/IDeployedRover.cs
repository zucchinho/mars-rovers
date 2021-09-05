using Nasa.MarsMission.Rovers.Core.Description;

namespace Nasa.MarsMission.Rovers.Core.Agent
{
    public interface IDeployedRover<TStatus> : IInputReceiver<string>, IRoverDetails
    {
        TStatus Status { get; set; }
    }
}