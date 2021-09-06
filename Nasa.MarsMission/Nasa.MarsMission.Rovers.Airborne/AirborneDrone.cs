using System;
using System.Collections.Generic;
using Nasa.MarsMission.Rovers.Core.Agent;

namespace Nasa.MarsMission.Rovers.Airborne
{
    public class AirborneDrone : DeployedRoverBase<DroneStatus, DroneAction>
    {
        protected override IEnumerable<DroneAction> Interpret(string input)
        {
            // TODO: interpret input e.g. "V10 R360 V-10"
            // list off 10m above ground, rotate once, land
            return Array.Empty<DroneAction>();
        }

        protected override void Execute(DroneAction action)
        {
            switch (action.Type)
            {
                case ActionType.Horizontal:
                    // TODO: move horizontally
                    break;
                case ActionType.Vertical:
                    // TODO: ascend/descend
                case ActionType.Rotate:
                    // TODO: rotate
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(action.Type),
                        $"Unrecognized rover action type: {action.Type}");
            }
        }
    }
}