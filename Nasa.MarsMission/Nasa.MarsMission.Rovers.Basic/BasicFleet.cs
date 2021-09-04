using System;
using System.Linq;
using Nasa.MarsMission.Rovers.Core;
using Nasa.MarsMission.Rovers.Core.Description.Terrain;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Basic
{
    public class BasicFleet : BaseCommandFleet<BasicRover, ITerrainSize>
    {
        private static readonly char[] PermittedChars = {'M', 'R', 'L'};
            
        protected override BasicRover GetRoverImplementation(int[] position, int bearing)
        {
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

            ActiveRover.CommandsProcessed++;
            ActiveRover.Ready = false;
            
            return ActiveRover;
        }
    }
}