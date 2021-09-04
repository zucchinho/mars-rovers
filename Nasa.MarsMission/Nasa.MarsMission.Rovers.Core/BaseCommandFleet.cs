using System.Collections.Generic;

namespace Nasa.MarsMission.Rovers.Core
{
    public abstract class BaseCommandFleet<TRover>
        : List<TRover>, ICommandFleet<TRover>
        where TRover : IDeployedRover
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

        protected abstract TRover GetRoverImplementation(int[] position, int bearing);
        protected abstract TRover GetActiveRover();
        protected abstract TRover InterpretCommandAndSend(string command);
    }
}