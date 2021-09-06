namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    /// <summary>
    /// An instruction to be issued to a fleet of rovers
    /// </summary>
    public class FleetInstruction
    {
        /// <summary>
        /// The type of instruction e.g. DeployRover
        /// </summary>
        public InstructionType Type { get; set; }

        /// <summary>
        /// The content of the instruction e.g. "0 1 S" for deployed rover status
        /// </summary>
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}, Content: {Content}";
        }
    }
}