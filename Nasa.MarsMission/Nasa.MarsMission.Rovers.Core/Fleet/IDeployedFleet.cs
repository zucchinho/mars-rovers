using Nasa.MarsMission.Rovers.Core.Description.Terrain;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public interface IDeployedFleet<TRover, in TTerrain> : ICommandFleet<TRover>
        where TRover : IDeployedRover 
        where TTerrain : ITerrainSize
    {
        ITerrainSize TerrainSize { get; }
        void SetTerrain(TTerrain terrain);
    }
}