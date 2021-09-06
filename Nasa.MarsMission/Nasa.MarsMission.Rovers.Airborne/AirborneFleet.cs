using System.Text.RegularExpressions;
using Nasa.MarsMission.Rovers.Core.Fleet;

namespace Nasa.MarsMission.Rovers.Airborne
{
    public class AirborneFleet : DeployedFleetBase<AirborneDrone, DroneStatus, DroneAirspace>
    {
        protected override Regex DeployRoverPattern { get; } = new(@"^\d+ \d+ [0-360]{1}$");
        protected override Regex InstructRoverPattern { get; }
        
        protected override AirborneDrone GetRoverInstance(DroneStatus roverStatus)
        {
            // TODO: create a new drone instance
            // this could be delegated to a factory function passed to the constructor
            throw new System.NotImplementedException();
        }

        protected override AirborneDrone GetActiveRover()
        {
            // TODO: this will likely be similar, but could
            // also be predicated on whether the rover is in flight,
            // or out of solar or something...
            throw new System.NotImplementedException();
        }

        protected override DroneStatus ExtractRoverStatus(string input)
        {
            // TODO: pretty straight forward, same as the other one
            // but also pull out height and now bearing/position
            // are continuous
            throw new System.NotImplementedException();
        }

        protected override DroneAirspace ExtractTerrain(string input)
        {
            // TODO: extract the terrain, for example, this would contain
            // the horizontal boundaries, max height and could include
            // any rocky terrain you wouldn't want the drone flying too low over
            // or landing in
            throw new System.NotImplementedException();
        }
    }
}