namespace Nasa.MarsMission.Rovers.Core
{
    public interface ICommandFleet<TRover> : IRoverFleet<TRover>
        where TRover : IRover
    {
        TRover Deploy(int[] position, int bearing);
        TRover Send(string command);
    }
}