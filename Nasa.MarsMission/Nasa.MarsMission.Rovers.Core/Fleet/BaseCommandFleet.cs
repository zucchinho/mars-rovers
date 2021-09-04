using System.Collections.Generic;
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
            var newRover = GetRoverImplementation(position, bearing);
            
            Add(newRover);

            return newRover;
        }

        public TRover Send(string command)
        {
            return InterpretCommandAndSend(command);
        }
        
        public void SetTerrain(TTerrain terrain)
        {
            TerrainSize = terrain;
        }

        protected abstract TRover GetRoverImplementation(int[] position, int bearing);
        protected abstract TRover GetActiveRover();
        protected abstract TRover InterpretCommandAndSend(string command);
        public ITerrainSize TerrainSize { get; private set; }
    }
}