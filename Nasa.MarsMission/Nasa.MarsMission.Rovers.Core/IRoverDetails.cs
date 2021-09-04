namespace Nasa.MarsMission.Rovers.Core
{
    public interface IRoverDetails
    {
        string Designation { get; set; }
        bool Ready { get; set; }
        int CommandsProcessed { get; set; }
    }
}