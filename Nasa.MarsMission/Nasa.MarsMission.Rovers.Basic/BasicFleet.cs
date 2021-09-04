using System;
using System.Linq;
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

        protected override BasicRover InterpretCommandAndSend(string command)
        {
            if (ActiveRover == default(BasicRover))
            {
                throw new InvalidOperationException(
                    "There are no active rovers");
            }
            
            var steps = command.ToCharArray();

            if (!steps.All(s => PermittedChars.Contains(s)))
            {
                throw new ArgumentException(
                    $"Command string must contain only 'M', 'L', 'R'. Command received: {command}");
            }

            foreach (var step in steps)
            {
                switch (step)
                {
                    case 'L':
                        ActiveRover.Rotate(90);
                        break;
                    case 'R':
                        ActiveRover.Rotate(-90);
                        break;
                    case 'M':
                        ActiveRover.Move(1);
                        break;
                }
            }

            if (Terrain.IsOutOfBounds(ActiveRover.Position))
            {
                throw new InvalidOperationException(
                    "The specified command moves the rover to a position out of the bounds of the terrain.");
            }
            
            ActiveRover.CommandsProcessed++;
            ActiveRover.Ready = false;
            
            return ActiveRover;
        }
    }
}