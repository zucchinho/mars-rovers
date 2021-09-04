using System;
using System.Collections.Generic;
using System.Linq;
using Nasa.MarsMission.Rovers.Core.Agent;
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

            var rover = ActiveRover;
            
            if (rover == null)
            {
                throw new InvalidOperationException(
                    "There are no active rovers");
            }
            
            var actions = InterpretCommand(command);

            foreach (var action in actions)
            {
                rover.Receive(action);
            }

            if (Terrain.IsOutOfBounds(rover.Position))
            {
                throw new InvalidOperationException(
                    "The specified command moves the rover to a position out of the bounds of the terrain.");
            }
            
            rover.CommandsProcessed++;
            rover.Ready = false;
            
            return rover;
        }

        public TTerrain Terrain { get; set; }
        protected abstract TRover GetRoverImplementation(int[] position, int bearing);
        protected abstract TRover GetActiveRover();
        protected abstract IEnumerable<RoverAction> InterpretCommand(string command);
    }
}