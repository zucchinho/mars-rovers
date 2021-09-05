using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsMission.Rovers.Basic.Helpers;
using Nasa.MarsMission.Rovers.Core.Agent;

namespace Nasa.MarsMission.Rovers.Basic
{
    public abstract class SurfaceRoverBase : DeployedRoverBase<RoverLocation, RoverAction>
    {
        private static readonly char[] PermittedChars = {'M', 'R', 'L'};
        private readonly RoverLocation _status = new RoverLocation();
        
        protected override void Execute(RoverAction action)
        {
            switch (action.Type)
            {
                case ActionType.Move:
                    Move(action.Value);
                    break;
                case ActionType.Rotate:
                    Rotate(action.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(action.Type),
                        $"Unrecognized rover action type: {action.Type}");
            }
        }

        protected override IEnumerable<RoverAction> Interpret(string input)
        {
            var steps = input.ToCharArray();

            if (!steps.All(s => PermittedChars.Contains(s)))
            {
                throw new ArgumentException(
                    $"Command string must contain only 'M', 'L', 'R'. Command received: {input}");
            }
            
            foreach (var step in steps)
            {
                var action = step switch
                {
                    'L' => new RoverAction {Type = ActionType.Rotate, Value = 90},
                    'R' => new RoverAction {Type = ActionType.Rotate, Value = -90},
                    'M' => new RoverAction {Type = ActionType.Move, Value = 1},
                    _ => throw new ArgumentException(
                        $"Command string must contain only 'M', 'L', 'R'. Command received: {input}")
                };

                yield return action;
            }
        }
        
        protected abstract int[] Move(int magnitude);
        protected abstract int Rotate(int angleOfRotation);

        public override RoverLocation Status
        {
            get => _status;
            set
            {
                Bearing = value.Bearing;
                Position = value.Position;
            }
        }

        protected int Bearing
        {
            get => _status.Bearing;
            // ensure bearing is 0 - 360
            set => _status.Bearing = OrientationHelpers.NormalizeAngle(value);
        }

        protected int[] Position
        {
            get => _status.Position;
            set => _status.Position = value;
        }
    }
}