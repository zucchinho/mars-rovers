namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    public class FleetInstruction
    {
        public InstructionType Type { get; set; }
        public string Content { get; set; }

        public override string ToString()
        {
            return $"Type: {Type}, Content: {Content}";
        }
    }
}