using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsMission.Rovers.Core.Description.Terrain;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public abstract class BaseCommandFleet<TRover, TTerrain>
        : List<TRover>, IDeployedFleet<TRover, TTerrain>
        where TRover : IDeployedRover 
        where TTerrain : ITerrainSize
    {
        public TRover ActiveRover => GetActiveRover();

        public TRover Deploy(int[] position, int bearing)
        {
            if (Terrain == null)
            {
                throw new InvalidOperationException(
                    "Unable to deploy rover. Terrain has not been set");
            }
            
            var newRover = GetRoverImplementation(position, bearing);
            
            Add(newRover);

            return newRover;
        }

        public TRover Send(string command)
        {
            if (Count < 1)
            {
                throw new InvalidOperationException(
                    "There are no rovers deployed.");
            }
            
            return InterpretCommandAndSend(command);
        }

        public TTerrain Terrain { get; set; }
        protected abstract TRover GetRoverImplementation(int[] position, int bearing);
        protected abstract TRover GetActiveRover();
        protected abstract TRover InterpretCommandAndSend(string command);
    }
}