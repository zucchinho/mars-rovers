using System;
using Nasa.MarsMission.Rovers.Core.Agent;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public abstract class BaseDeployedRover : IDeployedRover
    {
        public IDeployedRover Receive(RoverAction roverAction)
        {
            switch (roverAction.Type)
            {
                case ActionType.Move:
                    Move(roverAction.Value);
                    break;
                case ActionType.Rotate:
                    Rotate(roverAction.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(roverAction.Type),
                        $"Unrecognized rover action type: {roverAction.Type}");
            }

            return this;
        }
        
        public abstract int[] Move(int magnitude);
        public abstract int Rotate(int angleOfRotation);
        public string Designation { get; set; }
        public bool Ready { get; set; }
        public int CommandsProcessed { get; set; }
        public virtual int Bearing { get; set; }
        public virtual int[] Position { get; set; }
    }
}