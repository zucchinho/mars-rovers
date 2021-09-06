namespace Nasa.MarsMission.Rovers.Core.Fleet
{
    /// <summary>
    /// Possible types of instruction for a fleet of rovers
    /// </summary>
    public enum InstructionType
    {
        /// <summary>
        /// Specify the terrain for exploration
        /// </summary>
        SetTerrain,

        /// <summary>
        /// Deploy a rover to the environment
        /// </summary>
        DeployRover,

        /// <summary>
        /// Issue a deployed rover with an instruction
        /// </summary>
        InstructRover
    }
}