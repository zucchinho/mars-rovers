using System;
using System.Text;

namespace Nasa.MarsMission.Rovers.Core.Agent
{
    /// <summary>
    /// A rover deployed to an environment
    /// </summary>
    /// <typeparam name="TStatus">The type of rover status.</typeparam>
    /// <typeparam name="TAction">The type of rover action.</typeparam>
    public abstract class DeployedRoverBase<TStatus, TAction>
        : InputReceiverBase<TAction, string>, IDeployedRover<TStatus>
    {
        /// <summary>
        /// The unique name of the rover
        /// </summary>
        public string Designation { get; set; } = Guid.NewGuid().ToString();
        
        /// <summary>
        /// Whether rover is ready to receive commands
        /// </summary>
        public bool Ready { get; set; }
        
        /// <summary>
        /// The number of commands processed by this rover
        /// </summary>
        public int CommandsProcessed { get; set; }
        
        /// <summary>
        /// The current status of the rover
        /// </summary>
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