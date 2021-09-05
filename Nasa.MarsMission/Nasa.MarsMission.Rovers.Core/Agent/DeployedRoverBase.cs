using System;
using System.Text;

namespace Nasa.MarsMission.Rovers.Core.Agent
{
    public abstract class DeployedRoverBase<TStatus, TAction>
        : InputReceiverBase<TAction, string>, IDeployedRover<TStatus>
    {
        public string Designation { get; set; } = Guid.NewGuid().ToString();
        public bool Ready { get; set; }
        public int CommandsProcessed { get; set; }
        public virtual TStatus Status { get; set; }

        public override string ToString()
        {
            return new StringBuilder($"Rover ${Designation}")
                .AppendLine($"Status: {Status}")
                .AppendLine($"Commands processed: {CommandsProcessed}")
                .AppendLine($"Ready: {Ready}").ToString();
        }
    }
}