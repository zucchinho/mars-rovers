using System;
using Nasa.MarsMission.Rovers.Core.Description.Terrain;

namespace Nasa.MarsMission.Rovers.Airborne
{
    public class DroneAirspace : ITerrain<DroneStatus>
    {
        public int[] Dimensions { get; set; }
        
        public bool IsOutOfBounds(DroneStatus position)
        {
            // TODO: ensure the drone is not flying too high, 
            // or too low over rocky terrain
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Dimensions: ({string.Join(',', Dimensions)})";
        }
    }
}