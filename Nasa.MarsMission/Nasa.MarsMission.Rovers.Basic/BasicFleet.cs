using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsMission.Rovers.Core.Agent;
using Nasa.MarsMission.Rovers.Core.Description.Terrain;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicFleet : BaseCommandFleet<BasicRover, ITerrainSize>
    {
        private static readonly char[] PermittedChars = {'M', 'R', 'L'};
            
        protected override BasicRover GetRoverImplementation(int[] position, int bearing)
        {
            if (Terrain.IsOutOfBounds(position))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(position),
                    $"The initial position is out of the bounds of the terrain. Initial position: ({position[0]}, {position[1]})");
            }
            
            return new BasicRover
            {
                Ready = true,
                Position = position,
                Bearing = bearing,
                Designation = Guid.NewGuid().ToString()
            };
        }

        protected override BasicRover GetActiveRover()
        {
            return this.FirstOrDefault(r => r.Ready);
        }

        protected override IEnumerable<RoverAction> InterpretCommand(string command)
        {
            var steps = command.ToCharArray();

            if (!steps.All(s => PermittedChars.Contains(s)))
            {
                throw new ArgumentException(
                    $"Command string must contain only 'M', 'L', 'R'. Command received: {command}");
            }
            
            foreach (var step in steps)
            {
                var action = step switch
                {
                    'L' => new RoverAction {Type = ActionType.Rotate, Value = 90},
                    'R' => new RoverAction {Type = ActionType.Rotate, Value = -90},
                    'M' => new RoverAction {Type = ActionType.Move, Value = 1},
                    _ => throw new ArgumentException(
                        $"Command string must contain only 'M', 'L', 'R'. Command received: {command}")
                };

                yield return action;
            }
        }
    }
}