using Nasa.MarsMission.Rovers.Core.Description.Terrain;

namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public interface IDeployedFleet<TRover, TTerrain> : ICommandFleet<TRover>
        where TRover : IDeployedRover 
        where TTerrain : ITerrainSize
    {
        TTerrain Terrain { get; set; }
    }
}